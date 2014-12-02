using NUnit.Framework;
using System;

namespace CertiPay.Taxes.Federal.Tests
{
    public class FederalWithholdingCalculatorTests
    {
        private readonly IFederalWithholdingCalculator _calculator = new FederalWithholdingCalculator { };

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Verify_Invalid_Year()
        {
            _calculator.Calculate(1965, 100);
        }

        [Test, ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Verify_Negative_Income()
        {
            _calculator.Calculate(2013, -10);
        }
    }
}