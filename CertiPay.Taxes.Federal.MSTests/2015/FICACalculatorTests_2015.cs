//using NUnit.Framework;
//using System;

//namespace CertiPay.Taxes.Federal.Tests
//{
//    [Year(YEAR)]
//    public class FICACalculatorTests_2015
//    {
//        private const int YEAR = 2015;

//        private readonly IFICACalculator _calculator = new FICACalculator { };

//        [Theory]
//        public void Ensure_SS_Employee_Matches_Employer([Random(0, 1000000.00, 10)]Decimal income)
//        {
//            var result = _calculator.Calculate(YEAR, income);

//            Assert.AreEqual(result.SocialSecurity, result.SocialSecurity_Employer);
//        }

//        [Theory]
//        public void Ensure_Medicare_Employee_Matches_Employer([Random(0, 1000000.00, 10)]Decimal income)
//        {
//            var result = _calculator.Calculate(YEAR, income);

//            Assert.AreEqual(result.Medicare_Employer, result.Medicare);
//        }

//        [Theory]
//        public void Ensure_SS_Wage_Base_Applied([Random(0, 1000000.00, 25)]Decimal income)
//        {
//            var result = _calculator.Calculate(YEAR, income);

//            // Maximum for 2015 is $7,347.00, regardless of income

//            Assert.That(result.SocialSecurity, Is.GreaterThanOrEqualTo(0).And.AtMost(7347));
//            Assert.That(result.SocialSecurity_Employer, Is.GreaterThanOrEqualTo(0).And.AtMost(7347));
//        }

//        [Test]
//        [TestCase(15000, 217.50)]
//        [TestCase(74000, 1073)]
//        [TestCase(36500, 529.25)]
//        [TestCase(116999, 1696.49)]
//        [TestCase(300000, 4350)]
//        public void Calculate_Medicare_Taxes(Decimal income, Decimal expectedTaxes)
//        {
//            var result = _calculator.Calculate(YEAR, income);

//            Assert.AreEqual(expectedTaxes, result.Medicare);

//            Assert.AreEqual(result.Medicare, result.Medicare_Employer);
//        }

//        [Test]
//        [TestCase(15000, 930)]
//        [TestCase(74000, 4588)]
//        [TestCase(36500, 2263)]
//        [TestCase(116999, 7253.94)]
//        [TestCase(999999.99, 7347)]
//        public void Calculate_SS_Taxes(Decimal income, Decimal expectedTaxes)
//        {
//            var result = _calculator.Calculate(YEAR, income);

//            Assert.AreEqual(expectedTaxes, result.SocialSecurity);

//            Assert.AreEqual(result.SocialSecurity, result.SocialSecurity_Employer);
//        }
//    }
//}