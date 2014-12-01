using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Taxes.Federal
{
    public interface IFederalWithholdingCalculator
    {
        // TODO Calculate with allowances?

        Decimal Calculate(int year, Decimal annualIncome, EmployeeTaxFilingStatus filingStatus = EmployeeTaxFilingStatus.Single, int withholdingAllowances = 0);
    }

    public class FederalWithholdingCalculator : IFederalWithholdingCalculator
    {
        public const int Minimum_Year = 2013;

        public Decimal Calculate(int year, decimal annualIncome, EmployeeTaxFilingStatus filingStatus = EmployeeTaxFilingStatus.Single, int withholdingAllowances = 0)
        {
            if (year < Minimum_Year) throw new ArgumentOutOfRangeException("Unable to process tax years before " + Minimum_Year);

            if (annualIncome < 0) throw new ArgumentOutOfRangeException("AnnualIncome cannot be negative");

            if (withholdingAllowances < 0) throw new ArgumentOutOfRangeException("withholdingAllowances cannot be negative");

            // Get the appropriate table by year and filing status

            // Calculate the appropriate amount of withholdings based in annual income

            // Subtract the appropriate amount based in withholding allowances

            // Return the value

            // TODO

            return Decimal.Zero;
        }
    }
}
