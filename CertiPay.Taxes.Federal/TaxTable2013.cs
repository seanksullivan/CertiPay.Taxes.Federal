using CertiPay.Payroll.Common;
using System.Collections.Generic;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2013 : TaxTable
    {
        public int Year { get { return 2013; } }

        public IEnumerable<TaxTableEntry> Entries
        {
            get
            {
                return new[]
                {
                    //Schedule X — Single
                    //If taxable income is over--	But not over--	The tax is:
                    //$0	$8,925	10% of the amount over $0
                    //$8,925	$36,250	$892.50 plus 15% of the amount over $8,925
                    //$36,250	$87,850	$4,991.25 plus 25% of the amount over $36,250
                    //$87,850	$183,250	$17,891.25 plus 28% of the amount over $87,850
                    //$183,250	$398,350	$44,603.25 plus 33% of the amount over $183,250
                    //$398,350	$400,000	$115,586.25 plus 35% of the amount over $398,350
                    //$400,000	no limit	$116,163.75 plus 39.6% of the amount over $400,000

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 0, Maximum = 8925, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 8925, Maximum = 36250, Base = 892.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 36250, Maximum = 87850, Base = 4991.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 87850, Maximum = 183250, Base = 17891.25m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 183250, Maximum = 398350, Base = 44603.25m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 398350, Maximum = 400000, Base = 115586.25m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.Single, Minimum = 400000, Maximum = decimal.MaxValue, Base = 116163.75m, Percentage = 39.6m},
 
                    //Schedule Y-1 — Married Filing Jointly or Qualifying Widow(er)
                    //If taxable income is over--	But not over--	The tax is:
                    //$0	$17,850	10% of the amount over $0
                    //$17,850	$72,500	$1,785 plus 15% of the amount over $17,850
                    //$72,500	$146,400	$9,982.50 plus 25% of the amount over $72,500
                    //$146,400	$223,050	$28,457.50 plus 28% of the amount over $146,400
                    //$223,050	$398,350	$49,919.50 plus 33% of the amount over $223,050
                    //$398,350	$450,000	$107,768.50  plus 35% of the amount over $398,350
                    //$450,000	no limit	$125,846  plus 39.6% of the amount over $450,000

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 0, Maximum = 17850, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 17850, Maximum = 72500, Base = 1785, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 72500, Maximum = 146400, Base = 9982.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 146400, Maximum = 223050, Base = 28457.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 223050, Maximum = 398350, Base = 49919.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 398350, Maximum = 450000, Base = 107768.50m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingJointly, Minimum = 450000, Maximum = decimal.MaxValue, Base = 125846, Percentage = 39.6m},

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 0, Maximum = 17850, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 17850, Maximum = 72500, Base = 1785, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 72500, Maximum = 146400, Base = 9982.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 146400, Maximum = 223050, Base = 28457.50m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 223050, Maximum = 398350, Base = 49919.50m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 398350, Maximum = 450000, Base = 107768.50m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.WidowerWithDependentChild, Minimum = 450000, Maximum = decimal.MaxValue, Base = 125846, Percentage = 39.6m},

                    //Schedule Y-2 — Married Filing Separately
                    //If taxable income is over--	But not over--	The tax is:
                    //$0	$8,925	10% of the amount over $0
                    //$8,925	$36,250	$892.50 plus 15% of the amount over $8,925
                    //$36,250	$73,200	$4,991.25 plus 25% of the amount over $36,250
                    //$73,200	$111,525	$14,228.75 plus 28% of the amount over $73,200
                    //$111,525	$199,175	$24,959.75 plus 33% of the amount over $111,525
                    //$199,175	$225,000	$53,884.25 plus 35% of the amount over $199,025
                    //$225,000	no limit	$62,975.50 plus 39.6% of the amount over $225,000

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 0, Maximum = 8925, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 8925, Maximum = 36250, Base = 892.50m, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 36250, Maximum = 73200, Base = 4991.25m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 73200, Maximum = 111525, Base = 14228.75m, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 111525, Maximum = 199175, Base = 24959.75m, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 199175, Maximum = 225000, Base = 53884.25m, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.MarriedFilingSeparately, Minimum = 225000, Maximum = decimal.MaxValue, Base = 62975.50m, Percentage = 39.6m},

                    //Schedule Z — Head of Household
                    //If taxable income is over--	But not over--	The tax is:
                    //$0	$12,750	10% of the amount over $0
                    //$12,750	$48,600	$1,275 plus 15% of the amount over $12,750
                    //$48,600	$125,450	$6,625.50 plus 25% of the amount over $48,600
                    //$125,450	$203,150	$25,838 plus 28% of the amount over $125,450
                    //$203,150	$398,350	$47,594 plus 33% of the amount over $203,150
                    //$398,350	$425,000	$112,010 plus 35% of the amount over $398,350
                    //$425,000	no limit	$121,337.50 plus 39.6% of the amount over $425,000

                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 0, Maximum = 12750, Base = 0, Percentage = 10},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 12750, Maximum = 48600, Base = 1275, Percentage = 15},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 48600, Maximum = 125450, Base = 6625.50m, Percentage = 25},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 125450, Maximum = 203150, Base = 25828, Percentage = 28},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 203150, Maximum = 398350, Base = 47594, Percentage = 33},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 398350, Maximum = 425000, Base = 112010, Percentage = 35},
                    new TaxTableEntry{ TaxFilingStatus = EmployeeTaxFilingStatus.HeadOfHousehold, Minimum = 425000, Maximum = decimal.MaxValue, Base = 121337.50m, Percentage = 39.6m}
                };
            }
        }
    }
}