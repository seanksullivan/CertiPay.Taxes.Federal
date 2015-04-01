using CertiPay.Payroll.Common;
using System;
using System.Linq;

namespace CertiPay.Taxes.Federal
{
    public interface IAnnualizedIncomeCalculator
    {
        /// <summary>
        /// Calculate the annualized income minus any withholding allowances claimed.
        /// If the annualized income is less then the value of the allowances claimed, then Calculate
        /// will return 0 (it will never return a negative number).
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

            Decimal annualizedIncome = frequency.CalculateAnnualized(grossIncomeForPeriod);

            Decimal allowances_per_period = withholdingAllowances * allowancesValue.Value;

            Decimal value_of_allowances = frequency.CalculateAnnualized(allowances_per_period);

            // Annualized income cannot be less than 0. If the calculated income is less than the value of the allowances
            // then the employee will have no withholdings taken out.

            return Math.Max(annualizedIncome - value_of_allowances, 0);
        }
    }
}