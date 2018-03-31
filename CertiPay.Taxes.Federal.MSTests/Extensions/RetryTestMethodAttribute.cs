using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CertiPay.Taxes.Federal.MSTests.Extensions
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class RetryTestMethodAttribute : TestMethodAttribute
    {
        private bool _retry;
        private int _retryCount;

        public RetryTestMethodAttribute(bool retry, int retryCount)
        {
            _retry = retry;
            _retryCount = retryCount;
        }

        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var results = new List<TestResult>();

            // Execute the test
            var initialResults = ExecuteTest(testMethod);
            var testFailureExists = TestFailureExists(initialResults);

            // Add initial results to the collection
            results.AddRange(initialResults);

            if (_retryCount > 0 && testFailureExists)
            {
                for (var count = 0; count < _retryCount - 1; count++)
                {
                    // Execute test
                    var testResults = ExecuteTest(testMethod);

                    // Add results to the collection
                    results.AddRange(testResults);

                    // If 'Pass' then leave
                    if (!TestFailureExists(testResults))
                    {
                        // Cleanse the Results collection
                        results.Clear();

                        // Report the count of retried tests
                        testResults.FirstOrDefault().LogOutput = $"Retries until success: {count + 1} out of {_retryCount}";

                        // Add single 'Pass' results to the collection
                        results.AddRange(testResults);

                        // Exit the loop
                        break;
                    } 
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
