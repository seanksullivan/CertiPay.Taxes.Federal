using NUnit.Framework;
using System;

namespace CertiPay.Taxes.Federal.Tests
{
    public class FUTACalculatorTests_2014
    {
        private readonly IFUTACalculator _calculator = new FUTACalculator();

        private const int YEAR = 2014;

        [Test]
        [TestCase(5000, 300)]
        [TestCase(7500, 420)]
        [TestCase(99999, 420)]
        public void Calculate_Medicare_Taxes(Decimal income, Decimal expectedTaxes)
        {
            var result = _calculator.Calculate(YEAR, income);

            Assert.AreEqual(expectedTaxes, result);
        }
    }
}