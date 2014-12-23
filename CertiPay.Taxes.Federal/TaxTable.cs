using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public static class TaxTables
    {
        // TODO Update this when the other tables are filled in

        public const int Minimum_Year = 2013;

        public static IEnumerable<TaxTable> Values
        {
            get
            {
                return new TaxTable[]
                {
                    new TaxTable2011(),
                    new TaxTable2012(),
                    new TaxTable2013(),
                    new TaxTable2014(),
                    new TaxTable2015()
                };
            }
        }
    }

    public interface TaxTable
    {
        int Year { get; }

        IEnumerable<TaxTableEntry> Brackets { get; }

        IEnumerable<AllowanceValue> Allowances { get; }

        Decimal SocialSecurityWageBase { get; }

        Decimal FICA_EmployeePercentage { get; }

        Decimal FICA_EmployerPercentage { get; }

        Decimal MedicarePercentage { get; }

        /// <summary>
        /// The percentage of Federal Unemployment Insurnace Tax charged to the employer
        /// </summary>
        Decimal FUTA_EmployerPercentage { get; }

        /// <summary>
        /// The amount that the FUTA percentage is calculated off of, i.e. 6.0% of the first $7,000 wages
        /// </summary>
        Decimal FUTA_WageBase { get; }
    }
}