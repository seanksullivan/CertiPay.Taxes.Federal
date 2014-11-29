using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Taxes.Federal
{
    public class TaxTableEntry
    {
        public Decimal Minimum { get; set; }

        public Decimal Maximum { get; set; }

        public Decimal Base { get; set; }

        public Decimal Percentage { get; set; }

        public Decimal Calculate(Decimal annualizedIncome, int withholdingAllowances = 0)
        {
            // TODO Calculate with allowances

            return Base + ((annualizedIncome - Minimum) * (Percentage / 100));
        }
    }
}
