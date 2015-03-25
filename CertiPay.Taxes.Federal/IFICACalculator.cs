using CertiPay.Payroll.Common;
using System;
using System.Linq;

namespace CertiPay.Taxes.Federal
{
    /// <summary>
    /// Represents the output of the Federal Insurance Contributions Act tax calculations
    /// </summary>
    public class FICAResult
    {
        public Decimal Medicare { get; set; }

        public Decimal SocialSecurity { get; set; }

        public Decimal Medicare_Employer { get; set; }

        public Decimal SocialSecurity_Employer { get; set; }
    }

    /// <summary>
    /// Calculates the Federal Insurance Contributions Act tax based on income and year
    /// </summary>
    public interface IFICACalculator
    {
        FICAResult Calculate(int year, Decimal adjustedGrossIncome);
    }

    public class FICACalculator : IFICACalculator
    {
        // From: Wikipedia http://en.wikipedia.org/wiki/Federal_Insurance_Contributions_Act_tax

        // For 2014, the employee's share of the Social Security portion of the
        // FICA tax is 6.2% of gross compensation up to a limit of $117,000 of gross
        // compensation (resulting in a maximum Social Security tax of $7,254).[8] This limit,
        // known as the Social Security Wage Base, goes up each year based on average national wages
        // and, in general, at a faster rate than the Consumer Price Index (CPI-U). For the calendar
        // years of 2011 and 2012, the employee's share was temporarily reduced to 4.2% of gross
        // compensation with a limit of $106,800 for 2011 and $110,100 for 2012.[9] The employee's
        // share of the Medicare portion of the tax is 1.45% of wages, with no limit on the amount of
        // wages subject to the Medicare portion of the tax.[10] Because some payroll compensation is
        // subject to state income tax withholding in addition to Social Security tax withholding and
        // Medicare tax withholding, the Social Security and Medicare taxes account for only a portion
        // of the total percentage an employee constructively pays.

        // The employer is also liable for 6.2% Social Security and 1.45% Medicare taxes,[11] making the
        // total Social Security tax 12.4% of wages and the total Medicare tax 2.9%. (Self-employed people are
        // responsible for the entire FICA percentage of 15.3% (= 12.4% + 2.9%), since they are in a sense
        // both the employer and the employed; however, see the section on self-employed people for more details.)

        // Self-Employed People

        // A tax similar to the FICA tax is imposed on the earnings of self-employed individuals, such as
        // independent contractors and members of a partnership. This tax is imposed not by the Federal Insurance
        // Contributions Act but instead by the Self-Employment Contributions Act of 1954, which is codified as
        // Chapter 2 of Subtitle A of the Internal Revenue Code, 26 U.S.C. § 1401  through 26 U.S.C. § 1403
        // (the "SE Tax Act"). Under the SE Tax Act, self-employed people are responsible for the entire percentage
        // of 15.3% (= 12.4% [Soc. Sec.] + 2.9% [Medicare]); however, the 15.3% multiplier is applied to 92.35% of
        // the business's net earnings from self-employment, rather than 100% of the gross earnings; the difference,
        // 7.65%, is half of the 15.3%, and makes the calculation fair in comparison to that of regular
        // (non-self-employed) employees. It does this by adjusting for the fact that employees' 7.65% share of
        // their SE tax is multiplied against a number (their gross income) that does not include the putative
        // "employer's half" of the self-employment tax. In other words, it makes the calculation fair because
        // employees do not get taxed on their employers' contribution of the second half of FICA, therefore
        // self-employed people should not get taxed on the second half of the self-employment tax. Similarly,
        // self-employed people also deduct half of their self-employment tax (schedule SE) from their gross
        // income on the way to arriving at their adjusted gross income (AGI). This levels the amount paid by
        // self-employed persons in comparison to regular employees, who do not pay general income tax on their
        // employers' contribution of the second half of FICA, just as they did not pay FICA tax on it either.

        // A number of state and local employers and their employees in the states of Alaska, California, Colorado,
        // Illinois, Louisiana, Maine, Massachusetts, Nevada, Ohio and Texas are currently exempt from paying the
        // Social Security portion of FICA taxes. They provide alternative retirement and pension plans to their
        // employees. FICA initially did not apply to state and local governments, which were later given the option
        // of participating. Over time, most have elected to participate but a substantial number remain outside the system.

        public FICAResult Calculate(int year, decimal adjustedGrossIncome)
        {
            // TODO We don't handle self-employed poeple here

            if (year < TaxTables.Minimum_Year) throw new ArgumentOutOfRangeException("Unable to process tax years before " + TaxTables.Minimum_Year);

            if (adjustedGrossIncome < 0) throw new ArgumentOutOfRangeException("AdjustedGrossIncome cannot be negative");

            TaxTable table = TaxTables.Values.SingleOrDefault(t => t.Year == year);

            if (table == null) throw new ArgumentOutOfRangeException("Unable to find tax table that matches parameters");

            // TODO We're not taking into account the Medicare Surtax (0.9% for income over $200k) that was implemented as part of the ACA in tax years 2013+

            var result = new FICAResult { };

            Decimal social_security_taxable = Math.Min(table.SocialSecurityWageBase, adjustedGrossIncome);

            result.SocialSecurity = (social_security_taxable * (table.FICA_EmployeePercentage / 100)).Round();

            result.SocialSecurity_Employer = (social_security_taxable * (table.FICA_EmployerPercentage / 100)).Round();

            // Medicare does not have a "wage base", it's applicable to all earned income

            result.Medicare = result.Medicare_Employer = (adjustedGrossIncome * (table.MedicarePercentage / 100)).Round();

            return result;
        }
    }
}