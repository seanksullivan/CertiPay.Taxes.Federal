using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2011 : TaxTable
    {
        public int Year { get { return 2011; } }

        public Decimal SocialSecurityWageBase { get { return 106800; } }

        public Decimal FICA_EmployeePercentage { get { return 6.2m; } }

        public Decimal FICA_EmployerPercentage { get { return 4.2m; } }

        public Decimal MedicarePercentage { get { return 1.450m; } }

        // Through June 30, 2011, this included the extra 0.2 before going back to 6.0 for the rest of the year.
        // Good luck if you're calculating old taxes.
        public Decimal FUTA_EmployerPercentage { get { return 6.2m; } }

        public Decimal FUTA_WageBase { get { return 7000; } }

        public IEnumerable<TaxTableEntry> Brackets
        {
            get
            {
                return new TaxTableEntry[]
                {
                    // TODO
                };
            }
        }

        public IEnumerable<AllowanceValue> Allowances
        {
            get
            {
                return new AllowanceValue[]
                {
                    // TODO
                };
            }
        }
    }
}