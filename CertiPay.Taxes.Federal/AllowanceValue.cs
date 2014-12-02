namespace CertiPay.Taxes.Federal
{
    using CertiPay.Payroll.Common;
    using System;

    /// <summary>
    /// Represents the value of an allowance for calculating adjusted gross income from a W-4
    /// for a given payroll frequency
    /// </summary>
    public class AllowanceValue
    {
        public PayrollFrequency PayrollFrequency { get; set; }

        public Decimal Value { get; set; }
    }
}