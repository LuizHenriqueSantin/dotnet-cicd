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
}
