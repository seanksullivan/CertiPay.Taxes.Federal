using NUnit.Framework;

namespace CertiPay.Taxes.Federal.Tests
{
    public class YearAttribute : CategoryAttribute
    {
        public YearAttribute(int year)
            : base("" + year)
        {
        }

        public YearAttribute(string year)
            : base(year)
        {
        }
    }
}