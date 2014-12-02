using CertiPay.Payroll.Common;
using System;

namespace CertiPay.Taxes.Federal
{
    public class TaxTableEntry
    {
        public EmployeeTaxFilingStatus TaxFilingStatus { get; set; }

        public Decimal Minimum { get; set; }

        public Decimal Maximum { get; set; }

        public Decimal Base { get; set; }

        public Decimal Percentage { get; set; }
    }
}