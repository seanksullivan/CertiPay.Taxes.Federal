# CertiPay.Taxes.Federal

## Description

`CertiPay.Taxes.Federal` includes several useful calculators and the Federal income tax tables for use in calculating payroll taxes.

It depends on some classes available in `CertiPay.Payroll.Common` also available on GitHub and NuGet.

## Usage

Most of the calculators are straight-forward and have self-explanatory parameters.

### IAnnualizedIncomeCalculator

IAnnualizedIncomeCalculator calc = new AnnualizedIncomeCalculator();

Decimal result = calc.Calculate(year: 2014, grossIncomeForPeriod: 1000, frequency: PayrollFrequency.Weekly, withholdingAllowances: 2);

### IFederalWithholdingCalculator

### IFICACalculator

### IFUTACalculator

## Contributing