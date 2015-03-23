using NUnit.Framework;
using System;

namespace CertiPay.Taxes.Federal.Tests
{
    [Year(YEAR)]
    public class FUTACalculatorTests_2014
    {
        private readonly IFUTACalculator _calculator = new FUTACalculator();

        private const int YEAR = 2014;

        [Theory]
        public void Ensure_Does_Not_Pass_Wage_Base_Threshold([Random(0, 1000000.00, 20)]Decimal income)
        {
            Decimal max_futa_for_year = 740; // 7000 wage base x 6%

            Assert.That(_calculator.Calculate(YEAR, income), Is.AtMost(max_futa_for_year));
        }

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