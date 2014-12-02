using System;

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
}