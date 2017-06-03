using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CertiPay.Taxes.Federal;
using System.Diagnostics.CodeAnalysis;

namespace CertiPay.Taxes.Federal.MSTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class FederalWithholdingCalculatorMsTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Calculate_InvalidYear_VerifyException()
        {
            var calculator = new FederalWithholdingCalculator();
            calculator.Calculate(1965, 100);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Calculate_NegativeIncome_VerifyException()
        {
            var calculator = new FederalWithholdingCalculator();
            calculator.Calculate(2013, -10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Calculate_YearWithoutTables_VerifyException()
        {
            var calculator = new FederalWithholdingCalculator();
            calculator.Calculate(2050, 100);
        }
    }
}