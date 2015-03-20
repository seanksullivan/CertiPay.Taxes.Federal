using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections;

namespace CertiPay.Taxes.Federal.Tests
{
    public class AnnualizedIncomeCalculatorTests_2015
    {
        private const int YEAR = 2015;

        private readonly IAnnualizedIncomeCalculator _calculator = new AnnualizedIncomeCalculator { };

        [Test, TestCaseSource(typeof(TestCases), "Tests")]
        public Decimal Verify_Annual_Income_in_2015(Decimal payperiodIncome, PayrollFrequency frequency, int withholdingAllowances)
        {
            return _calculator.Calculate(YEAR, payperiodIncome, frequency, withholdingAllowances);
        }

        public class TestCases
        {
            public static IEnumerable Tests
            {
                get
                {
                    // No allowances

                    yield return new TestCaseData(10m, PayrollFrequency.Annually, 0).Returns(10);
                    yield return new TestCaseData(10m, PayrollFrequency.Quarterly, 0).Returns(40);
                    yield return new TestCaseData(10m, PayrollFrequency.Monthly, 0).Returns(120);
                    yield return new TestCaseData(10m, PayrollFrequency.SemiMonthly, 0).Returns(240);
                    yield return new TestCaseData(10m, PayrollFrequency.BiWeekly, 0).Returns(260);
                    yield return new TestCaseData(10m, PayrollFrequency.Weekly, 0).Returns(520);
                    yield return new TestCaseData(10m, PayrollFrequency.Daily, 0).Returns(2600);

                    // Single allowances

                    yield return new TestCaseData(10000m, PayrollFrequency.Annually, 1).Returns(6050);
                    yield return new TestCaseData(10000m, PayrollFrequency.Quarterly, 1).Returns(36050);
                    yield return new TestCaseData(1000m, PayrollFrequency.Monthly, 1).Returns(8049.60);
                    yield return new TestCaseData(1000m, PayrollFrequency.SemiMonthly, 1).Returns(20049.60);
                    yield return new TestCaseData(1000m, PayrollFrequency.BiWeekly, 1).Returns(22050.60);
                    yield return new TestCaseData(1000m, PayrollFrequency.Weekly, 1).Returns(48048);
                    yield return new TestCaseData(100m, PayrollFrequency.Daily, 1).Returns(22048);

                    // Multiple allowances

                    yield return new TestCaseData(100000m, PayrollFrequency.Annually, 3).Returns(88150.00);
                    yield return new TestCaseData(30000m, PayrollFrequency.Quarterly, 3).Returns(108150.00);
                    yield return new TestCaseData(3000m, PayrollFrequency.Monthly, 3).Returns(24148.80);
                    yield return new TestCaseData(3000m, PayrollFrequency.SemiMonthly, 3).Returns(60148.80);
                    yield return new TestCaseData(3000m, PayrollFrequency.BiWeekly, 3).Returns(66151.80);
                    yield return new TestCaseData(3000m, PayrollFrequency.Weekly, 3).Returns(144144.00);
                    yield return new TestCaseData(100m, PayrollFrequency.Daily, 3).Returns(14144);
                }
            }
        }
    }
}