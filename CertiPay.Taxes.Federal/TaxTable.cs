using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public interface TaxTable
    {
        int Year { get; }

        IEnumerable<TaxTableEntry> Brackets { get; }
    }
}