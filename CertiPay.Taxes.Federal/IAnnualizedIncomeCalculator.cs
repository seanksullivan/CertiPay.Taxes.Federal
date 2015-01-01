using CertiPay.Payroll.Common;
using System;
using System.Linq;

namespace CertiPay.Taxes.Federal
{
    public interface IAnnualizedIncomeCalculator
    {
        /// <summary>
        /// Calculate the annualized income minus any withholding allowances claimed
        /// </summary>
        Decimal Calculate(int year, Decimal grossIncomeForPeriod, PayrollFrequency frequency, int withholdingAllowances = 0);
    }

    public class AnnualizedIncomeCalculator : IAnnualizedIncomeCalculator
    {
        public decimal Calculate(int year, decimal grossIncomeForPeriod, PayrollFrequency frequency, int withholdingAllowances = 0)
        {
            if (year < TaxTables.Minimum_Year) throw new ArgumentOutOfRangeException("Unable to process tax years before " + TaxTables.Minimum_Year);

            if (grossIncomeForPeriod < 0) throw new ArgumentOutOfRangeException("AnnualIncome cannot be negative");

            if (withholdingAllowances < 0) throw new ArgumentOutOfRangeException("withholdingAllowances cannot be negative");

            AllowanceValue allowancesValue = TaxTables
                    .Values
                    .Where(t => t.Year == year)
                    .SelectMany(t => t.Allowances)
                    .Where(a => a.PayrollFrequency == frequency)
                    .SingleOrDefault();

            if (allowancesValue == null) throw new ArgumentOutOfRangeException("Unable to find tax table that matches parameters");

            Decimal netPayForPeriod = grossIncomeForPeriod - (withholdingAllowances * allowancesValue.Value);

            return frequency.CalculateAnnualized(netPayForPeriod).Round();
        }
    }
}