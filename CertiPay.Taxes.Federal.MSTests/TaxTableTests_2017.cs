using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CertiPay.Payroll.Common;

namespace CertiPay.Taxes.Federal.MSTests
{
    [TestClass]
    public class TaxTableTests4_2017
    {
        private TestContext testContextInstance;
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        private const int YEAR = 2017;

        [TestMethod]
        public void Calculate_ValidYear_Verify()
        {
            var calc = new FederalWithholdingCalculator();
            Assert.IsNotNull(calc.Calculate(YEAR, 1000));
        }

        /// <summary>
        /// MSTest2 example - using the DataRow atrribute, which is similar to nUnit's TestCase attribute - to provide data-driven unit test processing.
        /// </summary>
        /// <param name="annualIncome"></param>
        /// <param name="status"></param>
        /// <param name="expected"></param>
        [TestMethod]
        [DataRow(9325, EmployeeTaxFilingStatus.Single, 702.50)]
        [DataRow(85000, EmployeeTaxFilingStatus.Single, 16413.75)]
        [DataRow(46585, EmployeeTaxFilingStatus.Single, 6810)]
        [DataRow(123456, EmployeeTaxFilingStatus.Single, 26905.43)]
        [DataRow(67598, EmployeeTaxFilingStatus.Single, 12063.25)]
        [DataRow(18650, EmployeeTaxFilingStatus.MarriedFilingJointly, 1000)]
        [DataRow(85000, EmployeeTaxFilingStatus.MarriedFilingJointly, 10565)]
        [DataRow(123456, EmployeeTaxFilingStatus.MarriedFilingJointly, 20179)]
        [DataRow(9325, EmployeeTaxFilingStatus.MarriedFilingSeparately, 702.50)]
        [DataRow(46585, EmployeeTaxFilingStatus.MarriedFilingSeparately, 6810)]
        [DataRow(123456, EmployeeTaxFilingStatus.MarriedFilingSeparately, 26905.43)]
        [DataRow(13350, EmployeeTaxFilingStatus.HeadOfHousehold, 1191.25)]
        [DataRow(40198, EmployeeTaxFilingStatus.HeadOfHousehold, 5218.45)]
        [DataRow(123456, EmployeeTaxFilingStatus.HeadOfHousehold, 26905.43)]
        public void Calculate_Withholding_Verify(int annualIncome, EmployeeTaxFilingStatus status, Double expected)
        {
            var calc = new FederalWithholdingCalculator();
            Assert.AreEqual(Convert.ToDecimal(expected), calc.Calculate(YEAR, annualIncome, status));
        }

        /// <summary>
        /// Example: Using the MSTest DataSource attribute functionality to provide the same "TestCase" functionality as nUnit,
        /// but instead from a datasource like a Db, Excel, Xml, etc... to provide data-driven unit test processing.
        /// </summary>
        [TestMethod]
        [DeploymentItem("TestData\\WithHolding.xml")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\WithHolding.xml", "WithHolding", DataAccessMethod.Sequential)]
        public void Calculate_Withholding_VerifyViaXml()
        {
            // ARRANGE
            var annualIncome = Convert.ToInt32(TestContext.DataRow["AnnualIncome"]);
            var status = (EmployeeTaxFilingStatus)Enum.Parse(typeof(EmployeeTaxFilingStatus), TestContext.DataRow["Status"].ToString());
            var expected = Convert.ToDecimal(TestContext.DataRow["Expected"]);

            // ACT
            var calc = new FederalWithholdingCalculator();
            var result = calc.Calculate(YEAR, annualIncome, status);

            // ASSERT
            Assert.AreEqual(expected, result);
        }
    }
}
