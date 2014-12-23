using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2012 : TaxTable
    {
        public int Year { get { return 2012; } }

        public Decimal SocialSecurityWageBase { get { return 110100; } }

        public Decimal FICA_EmployeePercentage { get { return 6.2m; } }

        public Decimal FICA_EmployerPercentage { get { return 4.2m; } }

        public Decimal MedicarePercentage { get { return 1.450m; } }

        public Decimal FUTA_EmployerPercentage { get { return 6.0m; } }

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