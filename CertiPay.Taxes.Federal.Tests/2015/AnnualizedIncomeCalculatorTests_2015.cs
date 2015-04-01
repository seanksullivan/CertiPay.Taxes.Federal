using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections;

namespace CertiPay.Taxes.Federal.Tests
{
    [Year(YEAR)]
    public class AnnualizedIncomeCalculatorTests_2015
    {
        private const int YEAR = 2015;

        private readonly IAnnualizedIncomeCalculator _calculator = new AnnualizedIncomeCalculator { };

        [Theory]
        public void Verify_Approximate_Allowance_Value([Random(0, 1000.00, 30)]Decimal payperiodIncome, PayrollFrequency frequency, [Range(0, 10)]int withholdingAllowances)
        {
            // Allowances are worth $4000/year in 2015.
            // When I originally wrote the code for this, I was working from only part of the IRS publication that had
            // the allowance values listed based on payroll frequency, when really those are just deviated from the
            // total allowance value; this test runs through a subset of all possible inputs to verify that it's spitting out
            // about what we expect it to.

            Decimal allowance_value_annual = 4000;

            Decimal tolerance = 50.00m;

            Decimal expected = frequency.CalculateAnnualized(payperiodIncome) - (withholdingAllowances * allowance_value_annual);

            Assume.That(expected > 0);

            Assert.That(_calculator.Calculate(YEAR, payperiodIncome, frequency, withholdingAllowances), Is.EqualTo(expected).Within(tolerance));
        }

        [Test]
        [TestCase(500, PayrollFrequency.Monthly, 5)]
        [TestCase(3000, PayrollFrequency.Annually, 1)]
        [TestCase(3000, PayrollFrequency.Annually, 1)]
        public void Should_Not_Have_Negative_Annualized_Income(Decimal payperiodIncome, PayrollFrequency frequency, int withholdingAllowances)
        {
            Assert.AreEqual(0, _calculator.Calculate(YEAR, payperiodIncome, frequency, withholdingAllowances));
        }

        [Test, TestCaseSource(typeof(TestCases), "Tests")]
        public Decimal Verify_Annual_Income(Decimal payperiodIncome, PayrollFrequency frequency, int withholdingAllowances)
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

                    yield return new TestCaseData(10000m, PayrollFrequency.Annually, 1).Returns(6000);
                    yield return new TestCaseData(10000m, PayrollFrequency.Quarterly, 1).Returns(36000);
                    yield return new TestCaseData(1000m, PayrollFrequency.Monthly, 1).Returns(8000.40);
                    yield return new TestCaseData(1000m, PayrollFrequency.SemiMonthly, 1).Returns(19999.20);
                    yield return new TestCaseData(1000m, PayrollFrequency.BiWeekly, 1).Returns(22001.20);
                    yield return new TestCaseData(1000m, PayrollFrequency.Weekly, 1).Returns(48001.20);
                    yield return new TestCaseData(100m, PayrollFrequency.Daily, 1).Returns(21996);

                    // Multiple allowances

                    yield return new TestCaseData(100000m, PayrollFrequency.Annually, 3).Returns(88000.00);
                    yield return new TestCaseData(30000m, PayrollFrequency.Quarterly, 3).Returns(108000);
                    yield return new TestCaseData(3000m, PayrollFrequency.Monthly, 3).Returns(24001.20);
                    yield return new TestCaseData(3000m, PayrollFrequency.SemiMonthly, 3).Returns(59997.60);
                    yield return new TestCaseData(3000m, PayrollFrequency.BiWeekly, 3).Returns(66003.60);
                    yield return new TestCaseData(3000m, PayrollFrequency.Weekly, 3).Returns(144003.60);
                    yield return new TestCaseData(100m, PayrollFrequency.Daily, 3).Returns(13988);
                }
            }
        }
    }
}