using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2013 : TaxTable
    {
        public int Year { get { return 2013; } }

        public Decimal SocialSecurityWageBase { get { return 113700; } }

        public Decimal FICA_EmployeePercentage { get { return 6.2m; } }

        public Decimal FICA_EmployerPercentage { get { return FICA_EmployeePercentage; } }

        public Decimal MedicarePercentage { get { return 1.450m; } }

        public Decimal FUTA_EmployerPercentage { get { return 6.0m; } }

        public Decimal FUTA_WageBase { get { return 7000; } }

        public IEnumerable<TaxTableEntry> Brackets
        {
            get
            {
                return new[]
                {
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 0, Maximum = 1100, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 1100, Maximum = 5563, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 5563, Maximum = 19225, Base = 446.30m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 19225, Maximum = 45025, Base = 2495.60m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 45025, Maximum = 92725, Base = 8945.60m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 92725, Maximum = 200275, Base = 22301.60m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 200275, Maximum = 201100, Base = 57793.10m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 201100, Maximum = decimal.MaxValue, Base = 58081.85m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 0, Maximum = 8300, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 8300, Maximum = 26150, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 26150, Maximum = 80800, Base = 1785.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 80800, Maximum = 154700, Base = 9982.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 154700, Maximum = 231350, Base = 28457.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 231350, Maximum = 406650, Base = 49919.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 406650, Maximum = 458300, Base = 107768.50m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 458300, Maximum = decimal.MaxValue, Base = 125846.00m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 0, Maximum = 8450, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 8450, Maximum = 26600, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 26600, Maximum = 82250, Base = 1845.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 82250, Maximum = 157300, Base = 10312.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 157300, Maximum = 235300, Base = 29387.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 235300, Maximum = 413550, Base = 51577.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 413550, Maximum = 466050, Base = 111324.00m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 466050, Maximum = decimal.MaxValue, Base = 129996.50m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 0, Maximum = 1100, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 1100, Maximum = 5563, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 5563, Maximum = 19225, Base = 446.30m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 19225, Maximum = 45025, Base = 2495.60m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 45025, Maximum = 92725, Base = 8945.60m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 92725, Maximum = 200275, Base = 22301.60m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 200275, Maximum = 201100, Base = 57793.10m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 201100, Maximum = decimal.MaxValue, Base = 58081.85m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 0, Maximum = 1100, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 1100, Maximum = 5563, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 5563, Maximum = 19225, Base = 446.30m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 19225, Maximum = 45025, Base = 2495.60m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 45025, Maximum = 92725, Base = 8945.60m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 92725, Maximum = 200275, Base = 22301.60m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 200275, Maximum = 201100, Base = 57793.10m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 201100, Maximum = decimal.MaxValue, Base = 58081.85m, Percentage = 39.6m},
                
                };
            }
        }

        public IEnumerable<AllowanceValue> Allowances
        {
            get
            {
                //From the IRS Circular E Employer's Tax Guide
                //Table 5. Percentage Method—2013 Amount
                //for One Withholding Allowance
                //Payroll Period One Withholding
                //Allowance
                //Weekly .......................... $ 75.00
                //Biweekly ......................... 150.00
                //Semimonthly ...................... 162.50
                //Monthly .......................... 325.00
                //Quarterly ......................... 975.00
                //Semiannually ...................... 1,950.00
                //Annually ......................... 3,900.00
                //Daily or miscellaneous (each day of the payroll
                //period) .......................... 15.00

                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Weekly, Value = 75.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.BiWeekly, Value = 150.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.SemiMonthly, Value = 162.50m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Monthly, Value = 325.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Quarterly, Value = 975.00m };
                //yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Semiannually, Value = 1950.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Annually, Value = 3900.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Daily, Value = 15.00m };
            }
        }
    }
}