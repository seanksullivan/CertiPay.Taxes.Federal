using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2014 : TaxTable
    {
        public int Year { get { return 2014; } }

        public Decimal SocialSecurityWageBase { get { return 117000; } }

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
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 0, Maximum = 2250, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 2250, Maximum = 11325, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 11325, Maximum = 39150, Base = 907.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 39150, Maximum = 91600, Base = 5081.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 91600, Maximum = 188450, Base = 18193.75m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 188450, Maximum = 407350, Base = 45353.75m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 407350, Maximum = 409000, Base = 117541.25m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 409000, Maximum = decimal.MaxValue, Base = 118118.75m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 0, Maximum = 8450, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 8450, Maximum = 26600, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 26600, Maximum = 82250, Base = 1845.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 82250, Maximum = 157300, Base = 10312.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 157300, Maximum = 235300, Base = 29387.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 235300, Maximum = 413550, Base = 51577.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 413550, Maximum = 466050, Base = 111324.00m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 466050, Maximum = decimal.MaxValue, Base = 129996.50m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 0, Maximum = 8450, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 8450, Maximum = 26600, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 26600, Maximum = 82250, Base = 1845.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 82250, Maximum = 157300, Base = 10312.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 157300, Maximum = 235300, Base = 29387.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 235300, Maximum = 413550, Base = 51577.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 413550, Maximum = 466050, Base = 111324.00m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 466050, Maximum = decimal.MaxValue, Base = 129996.50m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 0, Maximum = 2250, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 2250, Maximum = 11325, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 11325, Maximum = 39150, Base = 907.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 39150, Maximum = 91600, Base = 5081.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 91600, Maximum = 188450, Base = 18193.75m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 188450, Maximum = 407350, Base = 45353.75m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 407350, Maximum = 409000, Base = 117541.25m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 409000, Maximum = decimal.MaxValue, Base = 118118.75m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 0, Maximum = 2250, Base = 0, Percentage = 0},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 2250, Maximum = 11325, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 11325, Maximum = 39150, Base = 907.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 39150, Maximum = 91600, Base = 5081.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 91600, Maximum = 188450, Base = 18193.75m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 188450, Maximum = 407350, Base = 45353.75m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 407350, Maximum = 409000, Base = 117541.25m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 409000, Maximum = decimal.MaxValue, Base = 118118.75m, Percentage = 39.6m},
                };
            }
        }

        public IEnumerable<AllowanceValue> Allowances
        {
            get
            {
                //From the IRS Circular E Employer's Tax Guide
                //Table 5. Percentage Method—2014 Amount
                //for One Withholding Allowance
                //Payroll Period One Withholding
                //Allowance
                //Weekly .......................... $ 76.00
                //Biweekly ......................... 151.90
                //Semimonthly ...................... 164.60
                //Monthly .......................... 329.20
                //Quarterly ......................... 987.50
                //Semiannually ...................... 1,975.00
                //Annually ......................... 3,950.00
                //Daily or miscellaneous (each day of the payroll
                //period) .......................... 15.20

                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Weekly, Value = 76.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.BiWeekly, Value = 151.90m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.SemiMonthly, Value = 164.60m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Monthly, Value = 329.20m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Quarterly, Value = 987.50m };
                //yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Semiannually, Value = 1975.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Annually, Value = 3950.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Daily, Value = 15.20m };
            }
        }
    }
}