using CertiPay.Payroll.Common;
using System;
using System.Linq;

namespace CertiPay.Taxes.Federal
{
    public interface IFederalWithholdingCalculator
    {
        /// <summary>
        /// Calculate the Federal withholdings to take for the given taxable gross income
        /// </summary>
        Decimal Calculate(int year, Decimal annualIncome, EmployeeTaxFilingStatus filingStatus = EmployeeTaxFilingStatus.Single);
    }

    public class FederalWithholdingCalculator : IFederalWithholdingCalculator
    {
        public Decimal Calculate(int year, decimal annualIncome, EmployeeTaxFilingStatus filingStatus = EmployeeTaxFilingStatus.Single)
        {
            if (year < TaxTables.Minimum_Year) throw new ArgumentOutOfRangeException("Unable to process tax years before " + TaxTables.Minimum_Year);

            if (annualIncome < 0) throw new ArgumentOutOfRangeException("AnnualIncome cannot be negative");

            // Get the appropriate table by year
            // Then figure out the correct row based on filing status and income

            TaxTableEntry entry = TaxTables
                .Values
                .Where(t => t.Year == year)
                .SelectMany(t => t.Brackets)
                .Where(e => e.TaxFilingStatus == filingStatus)
                .Where(e => e.Minimum <= annualIncome)
                .Where(e => annualIncome < e.Maximum)
                .Single();

            // Formula is Base amount + the difference between the income and the minimum for the bracket * the percentage in that bracket

            return entry.Base + ((annualIncome - entry.Minimum) * (entry.Percentage / 100));
        }
    }
}