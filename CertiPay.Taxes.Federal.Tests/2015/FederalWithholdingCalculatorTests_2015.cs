using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections;

namespace CertiPay.Taxes.Federal.Tests
{
    [Year(YEAR)]
    public class FederalWithholdingCalculatorTests_2015
    {
        private const int YEAR = 2015;

        private readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

        [Test]
        public void Verify_Valid_Year()
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
        public Decimal Verify_Withholding(Decimal annualIncome, EmployeeTaxFilingStatus status)
        {
            return _calculator.Calculate(YEAR, annualIncome, status);
        }

        public class TestCases
        {
            public static IEnumerable Tests
            {
                get
                {
                    // Single

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.Single).Returns(42071.25);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.Single).Returns(19671.25);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.Single).Returns(7043.75);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.Single).Returns(2856.75);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.Single).Returns(22471.25);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.Single).Returns(21070.97m);
                    yield return new TestCaseData(36900M, EmployeeTaxFilingStatus.Single).Returns(5073.75);
                    yield return new TestCaseData(405100M, EmployeeTaxFilingStatus.Single).Returns(117289.25m);
                    yield return new TestCaseData(200M, EmployeeTaxFilingStatus.Single).Returns(20);

                    // Married Filing Jointly

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(36051.50);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(15337.50);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(5827.50);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(2395.50);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(17837.50);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(16587.25);

                    // Married Filing Single

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(45514.50);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(20125.75);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(7043.75);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(2856.75);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(22925.75);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(21525.47);

                    // Widower -- Should match Married Filing Jointly

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(36051.50);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(15337.50);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(5827.50);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(2395.50);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(17837.50);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(16587.25);

                    // Head of Household

                    yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(39484.50);
                    yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(18072.50);
                    yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(6092.50);
                    yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(2660.50);
                    yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(20572.50);
                    yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(19322.25);

                    // Should fail

                    yield return new TestCaseData(-10M, EmployeeTaxFilingStatus.Single).Throws(typeof(ArgumentOutOfRangeException));
                }
            }
        }
    }
}