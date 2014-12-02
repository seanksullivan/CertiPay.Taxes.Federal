using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2015 : TaxTable
    {
        public int Year { get { return 2015; } }

        public Decimal SocialSecurityWageBase { get { return 118500; } }

        public Decimal FICA_EmployeePercentage { get { return 6.2m; } }

        public Decimal FICA_EmployerPercentage { get { return FICA_EmployeePercentage; } }

        public Decimal MedicarePercentage { get { return 1.450m; } }

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