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

        [Test]
        public void Should_Return_No_Withholding_For_Single(
            [Values(EmployeeTaxFilingStatus.Single, EmployeeTaxFilingStatus.MarriedFilingSeparately, EmployeeTaxFilingStatus.HeadOfHousehold)] EmployeeTaxFilingStatus status,
            [Random(0, 2300, 5)] Decimal annualIncome)
        {
            Assert.That(_calculator.Calculate(YEAR, annualIncome, status), Is.EqualTo(0));
        }

        [Test]
        public void Should_Return_No_Withholding_For_Married(
            [Values(EmployeeTaxFilingStatus.MarriedFilingJointly, EmployeeTaxFilingStatus.WidowerWithDependentChild)] EmployeeTaxFilingStatus status,
            [Random(0, 8600, 5)] Decimal annualIncome)
        {
            Assert.That(_calculator.Calculate(YEAR, annualIncome, status), Is.EqualTo(0));
        }

        [Test]
        public void Verify_Withholding_From_Pub15()
        {
            Assert.AreEqual(3187.50m, _calculator.Calculate(YEAR, 36000, EmployeeTaxFilingStatus.MarriedFilingJointly));
        }

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
                    //// Single

                    //yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.Single).Returns(42071.25);
                    //yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.Single).Returns(19671.25);
                    //yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.Single).Returns(7043.75);
                    //yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.Single).Returns(2856.75);
                    //yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.Single).Returns(22471.25);
                    //yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.Single).Returns(21070.97m);
                    //yield return new TestCaseData(36900M, EmployeeTaxFilingStatus.Single).Returns(5073.75);
                    //yield return new TestCaseData(405100M, EmployeeTaxFilingStatus.Single).Returns(117289.25m);
                    //yield return new TestCaseData(200M, EmployeeTaxFilingStatus.Single).Returns(20);

                    //// Married Filing Jointly

                    //yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(36051.50);
                    //yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(15337.50);
                    //yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(5827.50);
                    //yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(2395.50);
                    //yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(17837.50);
                    //yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.MarriedFilingJointly).Returns(16587.25);

                    //// Married Filing Single

                    //yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(45514.50);
                    //yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(20125.75);
                    //yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(7043.75);
                    //yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(2856.75);
                    //yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(22925.75);
                    //yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.MarriedFilingSeparately).Returns(21525.47);

                    //// Widower -- Should match Married Filing Jointly

                    //yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(36051.50);
                    //yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(15337.50);
                    //yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(5827.50);
                    //yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(2395.50);
                    //yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(17837.50);
                    //yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.WidowerWithDependentChild).Returns(16587.25);

                    //// Head of Household

                    //yield return new TestCaseData(175000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(39484.50);
                    //yield return new TestCaseData(95000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(18072.50);
                    //yield return new TestCaseData(45000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(6092.50);
                    //yield return new TestCaseData(22120M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(2660.50);
                    //yield return new TestCaseData(105000M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(20572.50);
                    //yield return new TestCaseData(99999M, EmployeeTaxFilingStatus.HeadOfHousehold).Returns(19322.25);

                    // Should fail

                    yield return new TestCaseData(-10M, EmployeeTaxFilingStatus.Single).Throws(typeof(ArgumentOutOfRangeException));
                }
            }
        }
    }
}