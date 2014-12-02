using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;
using System.Linq;

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

        private static readonly IEnumerable<TaxTable> tax_tables = new TaxTable[] { new TaxTable2013(), new TaxTable2014() };

        public Decimal Calculate(int year, decimal annualIncome, EmployeeTaxFilingStatus filingStatus = EmployeeTaxFilingStatus.Single, int withholdingAllowances = 0)
        {
            if (year < Minimum_Year) throw new ArgumentOutOfRangeException("Unable to process tax years before " + Minimum_Year);

            if (annualIncome < 0) throw new ArgumentOutOfRangeException("AnnualIncome cannot be negative");

            if (withholdingAllowances < 0) throw new ArgumentOutOfRangeException("withholdingAllowances cannot be negative");

            // Get the appropriate table by year
            // Then figure out the correct row based on filing status and income

            TaxTableEntry entry = tax_tables
                .Where(t => t.Year == year)
                .SelectMany(t => t.Entries)
                .Where(e => e.TaxFilingStatus == filingStatus)
                .Where(e => e.Minimum <= annualIncome)
                .Where(e => annualIncome < e.Maximum)
                .Single();

            // Calculate the appropriate amount of withholdings based in annual income

            var result = entry.Calculate(annualIncome, withholdingAllowances);

            // Subtract the appropriate amount based in withholding allowances

            // TODO

            return result;
        }
    }
}