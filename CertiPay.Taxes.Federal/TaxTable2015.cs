using CertiPay.Payroll.Common;
using System;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2015 : TaxTable
    {
        public int Year { get { return 2015; } }

        public Decimal SocialSecurityWageBase { get { return 118500; } }

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
                    // TODO: Need to double check these with the published IRS tables

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 0, Maximum = 9225, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 9225, Maximum = 37451, Base = 922.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 37451, Maximum = 90750, Base = 5156.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 90750, Maximum = 189300, Base = 18481.25m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 189300, Maximum = 411500, Base = 46075.25m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 411500, Maximum = 413200, Base = 119401.25m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 413200, Maximum = decimal.MaxValue, Base = 119996.25m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 0, Maximum = 18450, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 18450, Maximum = 74900, Base = 1845.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 74900, Maximum = 151200, Base = 10312.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 151200, Maximum = 230450, Base = 29387.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 230450, Maximum = 411500, Base = 51577.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 411500, Maximum = 464850, Base = 111324.00m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 464850, Maximum = decimal.MaxValue, Base = 129996.50m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 0, Maximum = 18450, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 18450, Maximum = 74900, Base = 1845.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 74900, Maximum = 151200, Base = 10312.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 151200, Maximum = 230450, Base = 29387.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 230450, Maximum = 411500, Base = 51577.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 411500, Maximum = 464850, Base = 111324.00m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 464850, Maximum = decimal.MaxValue, Base = 129996.50m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 0, Maximum = 9225, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 9225, Maximum = 37450, Base = 922.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 37450, Maximum = 75600, Base = 5156.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 75600, Maximum = 115225, Base = 14693.75m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 115225, Maximum = 205750, Base = 25788.75m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 205750, Maximum = 232425, Base = 55662.00m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 232425, Maximum = decimal.MaxValue, Base = 64998.25m, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 0, Maximum = 13150, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 13150, Maximum = 50200, Base = 1315.00m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 50200, Maximum = 129600, Base = 6872.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 129600, Maximum = 209850, Base = 26772.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 209850, Maximum = 411500, Base = 49192.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 411500, Maximum = 439000, Base = 115737m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 439000, Maximum = decimal.MaxValue, Base = 125362.00m, Percentage = 39.6m}
                };
            }
        }

        public IEnumerable<AllowanceValue> Allowances
        {
            get
            {
                //From the IRS Circular E Employer's Tax Guide

                //The wage amounts shown in the Percentage Method
                //Tables for Income Tax Withholding are net wages after
                //the deduction for total withholding allowances. The
                //withholding allowance amounts by payroll period have
                //changed. For 2015, they are:
                //Payroll Period
                //One Withholding
                //Allowance
                //Weekly $ 76.90
                //Biweekly 153.80
                //Semimonthly 166.70
                //Monthly 333.30
                //Quarterly 1,000.00
                //Semiannually 2,000.00
                //Annually 4,000.00
                //Daily or Miscellaneous
                //(each day of the payroll period)
                //15.40


                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Weekly, Value = 76.90m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.BiWeekly, Value = 153.80m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.SemiMonthly, Value = 166.70m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Monthly, Value = 333.30m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Quarterly, Value = 1000.00m };
                //yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Semiannually, Value = 2000.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Annually, Value = 4000.00m };
                yield return new AllowanceValue { PayrollFrequency = PayrollFrequency.Daily, Value = 15.40m };
            }
        }
    }
}