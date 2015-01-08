using CertiPay.Payroll.Common;
using System;
using System.Linq;

namespace CertiPay.Taxes.Federal
{
    /// <summary>
    /// Federal Unemployment (FUTA) Tax calculations
    /// </summary>
    public interface IFUTACalculator
    {
        /// <summary>
        /// Calculate the amount of FUTA taxes due by the employer up to the maximum allowed.
        /// Note that these taxes are "reduced" by a set percentage paid to the state fund for unemployment.
        /// </summary>
        Decimal Calculate(int year, Decimal adjustedGrossIncome);
    }

    public class FUTACalculator : IFUTACalculator
    {
        //Federal Unemployment (FUTA) Tax

        //The Federal Unemployment Tax Act, with state unemployment systems, provides for payments of unemployment
        //compensation to workers who have lost their jobs. Most employers pay both a federal and a state unemployment tax.
        //For a list of state unemployment agencies, visit the U.S. Department of Labor’s website at
        //www.workforcesecurity.doleta.gov/unemploy/agencies.asp. Only the employer pays FUTA tax; it is not
        //withheld from the employee's wages. For more information, see the Instructions for Form 940.

        //Computing FUTA tax.   For 2014, the FUTA tax rate is 6.0%. The tax applies to the first $7,000 you pay to each
        //employee as wages during the year. The $7,000 is the federal wage base. Your state wage base may be different.
        //Generally, you can take a credit against your FUTA tax for amounts you paid into state unemployment funds.
        //The credit may be as much as 5.4% of FUTA taxable wages. If you are entitled to the maximum 5.4% credit, the FUTA
        //tax rate after credit is 0.6%. You are entitled to the maximum credit if you paid your state unemployment taxes in
        //full, on time, and on all the same wages as are subject to FUTA tax, and as long as the state is not determined to
        //be a credit reduction state. See the Instructions for Form 940 to determine the credit.
        //In some states, the wages subject to state unemployment tax are the same as the wages subject to FUTA tax. However, certain states exclude some types of wages from state unemployment tax, even though they are subject to FUTA tax (for example, wages paid to corporate officers, certain payments of sick pay by unions, and certain fringe benefits). In such a case, you may be required to deposit more than 0.6% FUTA tax on those wages. See the Instructions for Form 940 for further guidance.

        // 2015, the FUTA Tax Rate remains 6.0%

        public Decimal Calculate(int year, Decimal adjustedGrossIncome)
        {
            TaxTable table = TaxTables.Values.Single(t => t.Year == year);

            Decimal taxable = Math.Min(table.FUTA_WageBase, adjustedGrossIncome);

            return (taxable * (table.FUTA_EmployerPercentage / 100)).Round();
        }
    }
}