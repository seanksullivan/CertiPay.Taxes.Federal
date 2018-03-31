using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.Federal.MSTests.Extensions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RetryTestMethodAttribute : TestMethodAttribute
    {
        private int _retryCount;

        public RetryTestMethodAttribute(int retryCount)
        {
            _retryCount = retryCount;

            // If this extension is utilized, the minimum value is 1 iteration
            if (_retryCount <= 0) _retryCount = 1;
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            // Initialize the TestResult list
            var results = new List<TestResult>();

            for (var count = 1; count <= _retryCount; count++)
            {
                // Execute test
                var testResults = ExecuteTest(testMethod);

                // Add results to the collection
                results.AddRange(testResults);

                // If 'Pass' then leave
                if (!TestFailureExists(testResults))
                {
                    // Cleanse the Results collection - we only wish to report Success, else MSTEST will report wholesale failure if at least one iteration/retry failed
                    results.Clear();

                    // Report the count of retried tests - if any retries occurred
                    if (count > 1)
                    {
                        testResults.FirstOrDefault().LogOutput = $"Retries until success: {count} out of a maximum of {_retryCount}";
                    }

                    // Add single 'Pass' results to the collection
                    results.AddRange(testResults);

                    // Exit the loop
                    break;
                } 
            }
            return results.ToArray();
        }

        private static bool TestFailureExists(List<TestResult> initialResults)
        {
            return initialResults.Exists(f => f.Outcome == UnitTestOutcome.Error || f.Outcome == UnitTestOutcome.Failed);
        }

        private List<TestResult> ExecuteTest(ITestMethod testMethod)
        {
            return base.Execute(testMethod).ToList();
        }
    }
}
