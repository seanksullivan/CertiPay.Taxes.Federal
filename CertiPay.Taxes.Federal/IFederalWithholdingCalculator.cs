using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Taxes.Federal
{
    public interface IFederalWithholdingCalculator
    {
        // TODO Calculate with allowances?

        Decimal Calculate(int year, Decimal annualIncome, FilingStatus filingStatus = FilingStatus.Single, int withholdingAllownaces = 0);
    }


}
