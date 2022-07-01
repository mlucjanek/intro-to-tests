using Xunit;

namespace Example.UnitTests;

public class Example
{
    [Fact]
    public void IncomeBelowBracketTriggerCountsInFirstBracket()
    {
        //Arrange
        var income = 100000;
        var expected = 17000;

        //Act
        var actual = TaxCalculator.GetYearlyTax(income, false, null);

        //Assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void IncomeAboveBracketTriggerCountsInFirstAndSecondBracket()
    {
        var income = 200000;

        var result = TaxCalculator.GetYearlyTax(income, false, null);

        Assert.Equal(46000, result);
    }


    [Theory]
    [InlineData(0, 28000)]
    [InlineData(60000, 37000)]
    [InlineData(120000, 46000)]
    public void SpouseDecreasesTax(decimal spouseIncome, decimal expected)
    {
        var income = 200000;

        var result = TaxCalculator.GetYearlyTax(income, true, spouseIncome);

        Assert.Equal(expected, result);
    }
}

internal static class TaxCalculator
{
    private const decimal FirstBracket = 0.17m;
    private const decimal SecondBracket = 0.32m;
    private const decimal BracketTrigger = 120000;

    public static decimal GetYearlyTax(decimal income, bool isMarried, decimal? spouseIncome)
    {
        var taxDuty = 0m;

        if (income < BracketTrigger)
        {
            taxDuty += income * FirstBracket;
            return taxDuty;
        }

        taxDuty += BracketTrigger * FirstBracket;
        income -= BracketTrigger;

        if (isMarried && spouseIncome.HasValue && spouseIncome <= BracketTrigger)
        {
            taxDuty += (BracketTrigger - spouseIncome.Value) * FirstBracket;
            income -= BracketTrigger - spouseIncome.Value;
        }

        taxDuty += income * SecondBracket;

        return taxDuty;
    }
}
