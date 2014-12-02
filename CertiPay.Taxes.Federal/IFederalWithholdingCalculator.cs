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
        // TODO: This might be dynamic, taken from what tables are loaded into memory
        public const int Minimum_Year = 2014;

        public Decimal Calculate(int year, decimal annualIncome, EmployeeTaxFilingStatus filingStatus = EmployeeTaxFilingStatus.Single, int withholdingAllowances = 0)
        {
            if (year < Minimum_Year) throw new ArgumentOutOfRangeException("Unable to process tax years before " + Minimum_Year);

            if (annualIncome < 0) throw new ArgumentOutOfRangeException("AnnualIncome cannot be negative");

            if (withholdingAllowances < 0) throw new ArgumentOutOfRangeException("withholdingAllowances cannot be negative");

            // Get the appropriate table by year and filing status

            // HACK: Hard-coded for 2014 and certain statuses for now!

            TaxTableEntry entry = default(TaxTableEntry);

            if (filingStatus == EmployeeTaxFilingStatus.Single)
            {
                entry = TaxTable2014.Single.Where(e => e.Minimum <= annualIncome && annualIncome < e.Maximum).Single();
            }
            else if (filingStatus == EmployeeTaxFilingStatus.MarriedFilingJointly)
            {
                entry = TaxTable2014.MarriedFilingJointly.Where(e => e.Minimum <= annualIncome && annualIncome < e.Maximum).Single();
            }

            // Calculate the appropriate amount of withholdings based in annual income

            var result = entry.Calculate(annualIncome, withholdingAllowances);

            // Subtract the appropriate amount based in withholding allowances

            // TODO

            return result;
        }
    }
}
