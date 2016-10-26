using NUnit.Framework;
using System;

namespace CertiPay.Taxes.Federal.Tests
{
    public class FederalWithholdingCalculatorTests
    {
        private readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

        [Test]
        public void Verify_Invalid_Year()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Calculate(1965, 100));
        }

        [Test]
        public void Verify_Negative_Income()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Calculate(2013, -10));
        }

        [Test]
        public void Verify_Year_Without_Tables()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.Calculate(2050, 100));
        }
    }
}