//using System;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using CertiPay.Payroll.Common;

//namespace CertiPay.Taxes.Federal.UnitTests
//{
//    [TestClass]
//    public class TaxTableTests_2017
//    {
//        private const int YEAR = 2017;

//        [TestMethod]
//        public void Calculate_ValidYear_Verify()
//        {
//            var calc = new FederalWithholdingCalculator();
//            Assert.IsNotNull(calc.Calculate(YEAR, 1000));
//        }

//        [TestMethod]
//        [DataRow(9325, EmployeeTaxFilingStatus.Single, 702.50)]
//        [DataRow(85000, EmployeeTaxFilingStatus.Single, 16413.75)]
//        [DataRow(46585, EmployeeTaxFilingStatus.Single, 6810)]
//        [DataRow(123456, EmployeeTaxFilingStatus.Single, 26905.43)]
//        [DataRow(67598, EmployeeTaxFilingStatus.Single, 12063.25)]
//        [DataRow(18650, EmployeeTaxFilingStatus.MarriedFilingJointly, 1000)]
//        [DataRow(85000, EmployeeTaxFilingStatus.MarriedFilingJointly, 10565)]
//        [DataRow(123456, EmployeeTaxFilingStatus.MarriedFilingJointly, 20179)]
//        [DataRow(9325, EmployeeTaxFilingStatus.MarriedFilingSeparately, 702.50)]
//        [DataRow(46585, EmployeeTaxFilingStatus.MarriedFilingSeparately, 6810)]
//        [DataRow(123456, EmployeeTaxFilingStatus.MarriedFilingSeparately, 26905.43)]
//        [DataRow(13350, EmployeeTaxFilingStatus.HeadOfHousehold, 1191.25)]
//        [DataRow(40198, EmployeeTaxFilingStatus.HeadOfHousehold, 5218.45)]
//        [DataRow(123456, EmployeeTaxFilingStatus.HeadOfHousehold, 26905.43)]
//        public void Calculate_Withholding_Verify(int annualIncome, EmployeeTaxFilingStatus status, Double expected)
//        {
//            var calc = new FederalWithholdingCalculator();
//            Assert.AreEqual(Convert.ToDecimal(expected), calc.Calculate(YEAR, annualIncome, status));
//        }

//        [TestMethod]
//        [DeploymentItem("TestData\\WithHolding.xml")]
//        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\SumTestData.xml", "WithHolding", DataAccessMethod.Sequential)]
//        public void Calculate_Withholding_Verify2()
//        {
//            // ARRANGE
//            var annualIncome = 0;
//            var status = EmployeeTaxFilingStatus.HeadOfHousehold;
//            var expected = 23.5m;

//            // ACT
//            var calc = new FederalWithholdingCalculator();
//            var result = calc.Calculate(YEAR, annualIncome, status);

//            // ASSERT
//            Assert.AreEqual(expected, result);
//        }
//    }
//}
