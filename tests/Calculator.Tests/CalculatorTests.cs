using Xunit;

namespace Calculator.Tests;

public class CalculatorTests
{
    [Fact]
    public void Add_ReturnsSum()
    {
        var calculator = new Calculator();

        var result = calculator.Add(2, 3);

        Assert.Equal(5, result);
    }

    [Fact]
    public void Subtract_ReturnsDifference()
    {
        var calculator = new Calculator();

        var result = calculator.Subtract(5, 3);

        Assert.Equal(2, result);
    }

    [Fact]
    public void Multiply_ReturnsProduct()
    {
        var calculator = new Calculator();

        var result = calculator.Multiply(4, 3);

        Assert.Equal(12, result);
    }

    [Fact]
    public void Divide_ReturnsQuotient()
    {
        var calculator = new Calculator();

        var result = calculator.Divide(10, 2);

        Assert.Equal(5, result);
    }

    [Fact]
    public void Divide_ByZero_Throws()
    {
        var calculator = new Calculator();

        Assert.Throws<DivideByZeroException>(() => calculator.Divide(10, 0));
    }

    [Fact]
    public void Add_WithNegativeNumbers_ReturnsSum()
    {
        var calculator = new Calculator();

        var result = calculator.Add(-2, -3);

        Assert.Equal(-5, result);
    }

    [Fact]
    public void Subtract_ResultingInNegativeNumber_ReturnsDifference()
    {
        var calculator = new Calculator();

        var result = calculator.Subtract(3, 5);

        Assert.Equal(-2, result);
    }

    [Fact]
    public void Multiply_ByZero_ReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Multiply(7, 0);

        Assert.Equal(0, result);
    }

    [Fact]
    public void Divide_ReturnsDecimalResult()
    {
        var calculator = new Calculator();

        var result = calculator.Divide(7, 2);

        Assert.Equal(3.5, result);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(-1, 1, 0)]
    [InlineData(0, 0, 0)]
    [InlineData(2.5, 2.5, 5)]
    public void Add_WithVariousInputs_ReturnsExpectedSum(double a, double b, double expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(a, b);

        Assert.Equal(expected, result);
    }
}
