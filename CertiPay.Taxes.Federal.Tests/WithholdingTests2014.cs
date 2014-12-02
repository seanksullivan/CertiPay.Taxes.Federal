using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections;

namespace CertiPay.Taxes.Federal.Tests
{
    public class WithholdingTests2014
    {
        private const int YEAR = 2014;

        private readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

        [Test]
        public void Verify_Valid_Year_2014()
        {
            Assert.NotNull(_calculator.Calculate(YEAR, 1000));
        }

        // Test Case From Wikipedia:

        // Assume, for example, that Taxpayer A is single and has a taxable income of $175,000 in 2014. The following steps apply the procedure outlined above:
        // (1) Because he is single, the pertinent rate table is Schedule X.[2]
        // (2) Given that his income falls between $89,350 and $186,350, he uses the fourth bracket in Schedule X.[2]
        // (3) His federal income tax will be “$18,193.75 plus 28% of the amount over $89,350.”[2] Applying this formula to Taxpayer A, one arrives at the following result:
        // $18,193.75 + (0.28 * ($175,000 - $89,350)) =
        // $18,193.75 + (0.28 * $85,650) =
        // $18,193.75 + $23,982 = $42,175.75.

        [Test, TestCaseSource(typeof(TestCases), "Tests")]
        public Decimal Verify_Withholding_2014(Decimal annualIncome, EmployeeTaxFilingStatus status)
        {
            return _calculator.Calculate(YEAR, annualIncome, status, 0);
        }

        public class TestCases
        {
            public static IEnumerable Tests
            {
                get
                {
                    // Single

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.Single).Returns(42175.75);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.Single).Returns(19775.75);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.Single).Returns(7106.25);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.Single).Returns(2864.25);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.Single).Returns(22575.75);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.Single).Returns(21175.47);

                    // Married Filing Jointly

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(36247.00);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(15462.50);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(5842.50);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(2410.50);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(17962.50);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(16712.25);

                    // Married Filing Single

                    // TODO

                    // Widower -- Should match Married Filing Jointly

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(36247.00);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(15462.50);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(5842.50);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(2410.50);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(17962.50);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(16712.25);

                    // Head of Household

                    // TODO
                }
            }
        }
    }
}