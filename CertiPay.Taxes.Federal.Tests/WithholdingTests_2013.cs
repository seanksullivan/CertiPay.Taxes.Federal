using CertiPay.Payroll.Common;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Taxes.Federal.Tests
{
    public class WithholdingTests_2013
    {
        const int YEAR = 2013;

        // Single
        // Married
        // MarriedFilingSingle
        // Widower

        readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

        [Test]
        public void Verify_Valid_Year()
        {
            Assert.NotNull(_calculator.Calculate(YEAR, 1000));
        }

        //[Test]
        //public void Verify_Withholding(Decimal annualIncome, EmployeeTaxFilingStatus status, Decimal expected)
        //{

        //}

        //[Test]
        //public void Verify_Withholding_Allownaces(Decimal annualIncome, EmployeeTaxFilingStatus status, int allowances, Decimal expected)
        //{

        //}
    }
}
