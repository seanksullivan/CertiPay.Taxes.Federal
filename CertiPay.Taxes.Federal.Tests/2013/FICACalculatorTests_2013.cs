using NUnit.Framework;
using System;

namespace CertiPay.Taxes.Federal.Tests
{
    [Year(YEAR)]
    public class FICACalculatorTests_2013
    {
        private const int YEAR = 2013;

        private readonly IFICACalculator _calculator = new FICACalculator { };

        [Test]
        [TestCase(15000, 217.50)]
        [TestCase(74000, 1073)]
        [TestCase(36500, 529.25)]
        [TestCase(116999, 1696.49)]
        [TestCase(300000, 4350)]
        public void Calculate_Medicare_Taxes(Decimal income, Decimal expectedTaxes)
        {
            var result = _calculator.Calculate(YEAR, income);

            Assert.AreEqual(expectedTaxes, result.Medicare);

            Assert.AreEqual(result.Medicare, result.Medicare_Employer);
        }

        [Test]
        [TestCase(15000, 930)]
        [TestCase(74000, 4588)]
        [TestCase(36500, 2263)]
        [TestCase(113699, 7049.34)]
        [TestCase(113701, 7049.40)]
        [TestCase(999999.99, 7049.40)]
        public void Calculate_SS_Taxes(Decimal income, Decimal expectedTaxes)
        {
            var result = _calculator.Calculate(YEAR, income);

            Assert.AreEqual(expectedTaxes, result.SocialSecurity);

            Assert.AreEqual(result.SocialSecurity, result.SocialSecurity_Employer);
        }
    }
}