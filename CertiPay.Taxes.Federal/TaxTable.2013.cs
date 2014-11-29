using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CertiPay.Taxes.Federal
{
    public sealed class TaxTable2013
    {
        //Schedule X — Single
        //If taxable income is over--	But not over--	The tax is:
        //$0	$9,075	10% of the amount over $0
        //$9,075	$36,900	$907.50 plus 15% of the amount over $9,075
        //$36,900	$89,350	$5,081.25 plus 25% of the amount over $36,900
        //$89,350	$186,350	$18,193.75 plus 28% of the amount over $89,350
        //$186,350	$405,100	$45,353.75 plus 33% of the amount over $186,350
        //$405,100	$406,750	$117,541.25 plus 35% of the amount over $405,100
        //$406,750	no limit	$118,118.75 plus 39.6% of the amount over $406,750



        //Schedule Y-1 — Married Filing Jointly or Qualifying Widow(er)
        //If taxable income is over--	But not over--	The tax is:
        //$0	$18,150	10% of the amount over $0
        //$18,150	$73,800	$1,815 plus 15% of the amount over $18,150
        //$73,800	$148,850	$10,162.50 plus 25% of the amount over $73,800
        //$148,850	$226,850	$28,925 plus 28% of the amount over $148,850
        //$226,850	$405,100	$50,765 plus 33% of the amount over $226,850
        //$405,100	$457,600	$109,587.50  plus 35% of the amount over $405,100
        //$457,600	no limit	$127,962.50  plus 39.6% of the amount over $457,600

        //Schedule Y-2 — Married Filing Separately
        //If taxable income is over--	But not over--	The tax is:
        //$0	$9.075	10% of the amount over $0
        //$9.075	$36,900	$907.50 plus 15% of the amount over $9.075
        //$36,900	$74,425	$5,081.25 plus 25% of the amount over $36,900
        //$74,425	$113,425	$14,462.50 plus 28% of the amount over $74,425
        //$113,425	$202,550	$25,382.50 plus 33% of the amount over $113,425
        //$202,550	$228,800	$54,793.75 plus 35% of the amount over $202,550
        //$228,800	no limit	$63,981.25 plus 39.6% of the amount over $228,800

        //Schedule Z — Head of Household
        //If taxable income is over--	But not over--	The tax is:
        //$0	$12,950	10% of the amount over $0
        //$12,950	$49,400	$1,295 plus 15% of the amount over $12,950
        //$49,400	$127,550	$6,762.50 plus 25% of the amount over $49,400
        //$127,550	$206,600	$26,300 plus 28% of the amount over $127,550
        //$206,600	$405,100	$48,434 plus 33% of the amount over $206,600
        //$405,100	$432,200	$113,939 plus 35% of the amount over $405,100
        //$432,200	no limit	$123,424 plus 39.6% of the amount over $432,200

    }
}
