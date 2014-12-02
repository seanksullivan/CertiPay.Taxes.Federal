using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public static class TaxTables
    {
        public static IEnumerable<TaxTable> Values
        {
            get
            {
                return new TaxTable[]
                {
                    new TaxTable2013(),
                    new TaxTable2014()
                };
            }
        }
    }

    public interface TaxTable
    {
        int Year { get; }

        IEnumerable<TaxTableEntry> Brackets { get; }

        Decimal SocialSecurityWageBase { get; }

        Decimal FICA_EmployeePercentage { get; }

        Decimal FICA_EmployerPercentage { get; }

        Decimal MedicarePercentage { get; }
    }
}