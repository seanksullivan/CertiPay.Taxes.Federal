using CertiPay.Payroll.Common;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CertiPay.Taxes.Federal;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;
using CertiPay.Taxes.Federal.MSTests.Extensions;
using System.Collections;

namespace CertiPay.Taxes.Federal.MSTests
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class AnnualizedIncomeCalculatorTests_2015
    {
        private const int YEAR = 2015;

        [RetryTestMethod(3)]
        public void MySpecial_Test()
        {
            // ARRANGE
            var calculator = new AnnualizedIncomeCalculator();
            var random = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            const Decimal allowanceValueAnnual = 4000;
            const Decimal tolerance = 50.00m;

            // Set the random data
            var payperiodIncome = Convert.ToDecimal(random.Next(0, 1000));
            var withholdingAllowances = random.Next(0, 10);

            var enumValues = Enum.GetValues(typeof(PayrollFrequency));
            var frequency = (PayrollFrequency)enumValues.GetValue(random.Next(1, enumValues.Length));

            // ACT
            var allowance = (withholdingAllowances * allowanceValueAnnual);
            var annualCalc = PayrollFrequencies.CalculateAnnualized(frequency, payperiodIncome);

            var annualMinusWithHolding = (annualCalc - (withholdingAllowances * allowanceValueAnnual));
            var calc = calculator.Calculate(YEAR, payperiodIncome, frequency, withholdingAllowances);

            // ASSERT
            Assert.IsTrue(annualMinusWithHolding > 0, $"Expected AnnualCalcMinusWithHolding greater than 0. AnnualCalcMinusWithHolding value:{annualMinusWithHolding}, Frequency:{frequency}");

            Assert.AreEqual((float)annualMinusWithHolding, (float)calc, (float)tolerance, $"Expected:{annualMinusWithHolding}, Calculated:{calc}, Tolerance:{tolerance}");
        }

        [IterativeTestMethod(100)]
        public void Verify_Approximate_Allowance_Value()
        {
            // ARRANGE
            var calculator = new AnnualizedIncomeCalculator();
            var random = new Random(int.Parse(Guid.NewGuid().ToString().Substring(0, 8), System.Globalization.NumberStyles.HexNumber));
            const Decimal allowanceValueAnnual = 4000;
            const Decimal tolerance = 50.00m;
            
            // Set the random data
            var payperiodIncome = Convert.ToDecimal(random.Next(0, 1000));
            var withholdingAllowances = random.Next(0, 10);
            

            var enumValues = Enum.GetValues(typeof(PayrollFrequency));
            var frequency = (PayrollFrequency)enumValues.GetValue(random.Next(1, enumValues.Length));

            // ACT
            var allowance = (withholdingAllowances * allowanceValueAnnual);
            var annualCalc = PayrollFrequencies.CalculateAnnualized(frequency, payperiodIncome);

            var annualMinusWithHolding = (annualCalc - (withholdingAllowances * allowanceValueAnnual));
            var calc = calculator.Calculate(YEAR, payperiodIncome, frequency, withholdingAllowances);

            // ASSERT
            Assert.IsTrue(annualMinusWithHolding > 0, $"Expected AnnualCalcMinusWithHolding greater than 0. AnnualCalcMinusWithHolding value:{annualMinusWithHolding}, Frequency:{frequency}");

            Assert.AreEqual((float)annualMinusWithHolding, (float)calc, (float)tolerance, $"Expected:{annualMinusWithHolding}, Calculated:{calc}, Tolerance:{tolerance}");
        }

        [TestMethod]
        [DataRow(500, PayrollFrequency.Monthly, 5)]
        [DataRow(3000, PayrollFrequency.Annually, 1)]
        [DataRow(3000, PayrollFrequency.Annually, 1)]
        public void Should_Not_Have_Negative_Annualized_Income(int payperiodIncome, PayrollFrequency frequency, int withholdingAllowances)
        {
            // ARRANGE
            var calculator = new AnnualizedIncomeCalculator();
            var payperiodIncomeValue = Convert.ToDecimal(payperiodIncome);

            // ACT
            var result = calculator.Calculate(YEAR, payperiodIncomeValue, frequency, withholdingAllowances);

            // ASSERT
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [DataRow(10, PayrollFrequency.Annually, 0, 10)]             // No allowances
        [DataRow(10, PayrollFrequency.Quarterly, 0, 40)]            // No allowances
        [DataRow(10, PayrollFrequency.Monthly, 0, 120)]             // No allowances
        [DataRow(10, PayrollFrequency.SemiMonthly, 0, 240)]         // No allowances
        [DataRow(10, PayrollFrequency.BiWeekly, 0, 260)]            // No allowances
        [DataRow(10, PayrollFrequency.Weekly, 0, 520)]              // No allowances
        [DataRow(10, PayrollFrequency.Daily, 0, 2600)]              // No allowances
        [DataRow(10000, PayrollFrequency.Annually, 1, 6000)]        // Single allowances
        [DataRow(10000, PayrollFrequency.Quarterly, 1, 36000)]      // Single allowances
        [DataRow(1000, PayrollFrequency.Monthly, 1, 8000.40)]       // Single allowances
        [DataRow(1000, PayrollFrequency.SemiMonthly, 1, 19999.20)]  // Single allowances
        [DataRow(1000, PayrollFrequency.BiWeekly, 1, 22001.20)]     // Single allowances
        [DataRow(1000, PayrollFrequency.Weekly, 1, 48001.20)]       // Single allowances
        [DataRow(100, PayrollFrequency.Daily, 1, 21996)]            // Single allowances
        [DataRow(100000, PayrollFrequency.Annually, 3, 88000)]      // Multiple allowances
        [DataRow(30000, PayrollFrequency.Quarterly, 3, 108000)]     // Multiple allowances
        [DataRow(3000, PayrollFrequency.Monthly, 3, 24001.20)]      // Multiple allowances
        [DataRow(3000, PayrollFrequency.SemiMonthly, 3, 59997.60)]  // Multiple allowances
        [DataRow(3000, PayrollFrequency.BiWeekly, 3, 66003.60)]  // Multiple allowances
        [DataRow(3000, PayrollFrequency.Weekly, 3, 144003.60)]      // Multiple allowances
        [DataRow(100, PayrollFrequency.Daily, 3, 13988)]            // Multiple allowances
        public void Verify_Annual_Income(int payperiodIncome, PayrollFrequency frequency, int withholdingAllowances, Double expectedResult)
        {
            // ARRANGE
            var calculator = new AnnualizedIncomeCalculator();
            var payperiodIncomeValue = Convert.ToDecimal(payperiodIncome);
            var expectedResultValue = Convert.ToDecimal(expectedResult);

            // ACT
            var result = calculator.Calculate(YEAR, payperiodIncomeValue, frequency, withholdingAllowances);

            // ASSERT
            Assert.AreEqual(expectedResultValue, result);
        }
    }
}