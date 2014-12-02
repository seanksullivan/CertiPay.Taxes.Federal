using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Taxes.Federal.Tests
{
    public class WithholdingTests2014
    {
        const int YEAR = 2014;

        readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

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

        [Test]
        [TestCase(175000, EmployeeTaxFilingStatus.Single, 42175.75)]
        [TestCase(95000, EmployeeTaxFilingStatus.Single, 19775.75)]
        [TestCase(45000, EmployeeTaxFilingStatus.Single, 7106.25)]
        [TestCase(22120, EmployeeTaxFilingStatus.Single, 2864.25)]
        [TestCase(105000, EmployeeTaxFilingStatus.Single, 22575.75)]
        [TestCase(99999, EmployeeTaxFilingStatus.Single, 21175.47)]
        [TestCase(175000, EmployeeTaxFilingStatus.MarriedFilingJointly, 36247.00)]
        [TestCase(95000, EmployeeTaxFilingStatus.MarriedFilingJointly, 15462.50)]
        [TestCase(45000, EmployeeTaxFilingStatus.MarriedFilingJointly, 5842.50)]
        [TestCase(22120, EmployeeTaxFilingStatus.MarriedFilingJointly, 2410.50)]
        [TestCase(105000, EmployeeTaxFilingStatus.MarriedFilingJointly, 17962.50)]
        [TestCase(99999, EmployeeTaxFilingStatus.MarriedFilingJointly, 16712.25)]
        public void Verify_Withholding_2014(Decimal annualIncome, EmployeeTaxFilingStatus status, Decimal expectedResult)
        {
            var result = _calculator.Calculate(YEAR, annualIncome, status, 0);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
