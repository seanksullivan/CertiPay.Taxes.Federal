using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections;

namespace CertiPay.Taxes.Federal.Tests._2017
{
    [Year(YEAR)]
    public class TaxTableTests_2017
    {
        private const int YEAR = 2017;

        private readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

        [Test]
        public void Verify_Valid_Year()
        {
            Assert.NotNull(_calculator.Calculate(YEAR, 1000));
        }

        [Test, TestCaseSource(typeof(TestCases), "Tests")]
        public void Verify_Withholding(int annualIncome, EmployeeTaxFilingStatus status, Decimal expected)
        {
            Assert.That(_calculator.Calculate(YEAR, annualIncome, status), Is.EqualTo(expected));
        }

        public class TestCases
        {
            public static IEnumerable Tests
            {
                get
                {
                    // Single

                    yield return new TestCaseData(9325, EmployeeTaxFilingStatus.Single, 932.50m);
                    yield return new TestCaseData(85000, EmployeeTaxFilingStatus.Single, 16988.75m);
                    yield return new TestCaseData(46585, EmployeeTaxFilingStatus.Single, 7385m);
                    yield return new TestCaseData(123456, EmployeeTaxFilingStatus.Single, 27549.43m);
                    yield return new TestCaseData(67598, EmployeeTaxFilingStatus.Single, 12638.25m);

                    // Married Filing Joint

                    yield return new TestCaseData(18650, EmployeeTaxFilingStatus.MarriedFilingJointly, 1865m);
                    yield return new TestCaseData(85000, EmployeeTaxFilingStatus.MarriedFilingJointly, 12727.50m);
                    yield return new TestCaseData(123456, EmployeeTaxFilingStatus.MarriedFilingJointly, 22341.50m);

                    // Married Filing Separate

                    yield return new TestCaseData(9325, EmployeeTaxFilingStatus.MarriedFilingSeparately, 932.50m);
                    yield return new TestCaseData(46595, EmployeeTaxFilingStatus.MarriedFilingSeparately, 7387.50m);
                    yield return new TestCaseData(123456, EmployeeTaxFilingStatus.MarriedFilingSeparately, 28348.98m);

                    // Head of Household

                    yield return new TestCaseData(13350, EmployeeTaxFilingStatus.HeadOfHousehold, 1335m);
                    yield return new TestCaseData(40198, EmployeeTaxFilingStatus.HeadOfHousehold, 5362.20m);
                    yield return new TestCaseData(123456, EmployeeTaxFilingStatus.HeadOfHousehold, 25116.50m);
                }
            }
        }
    }
}