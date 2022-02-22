using System;
using System.Linq;
using Xunit;

namespace NameCalculator.Calculator.UnitTests;

public class CalculatorServiceTests
{
    private const string ValidFirstName = "John";
    private const string ValidLastName = "Doe";

    [Fact]
    public void Calculate_WhenAllGivenParametersAreValid_ShouldSucceeded()
    {
        //arrange
        const int numberOfExpectedResults = 100;
        var calculatorService = new CalculatorService();

        //act
        var result = calculatorService.Calculate(ValidFirstName, ValidLastName);

        //assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.Equal(numberOfExpectedResults, result.Count);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void Calculate_WhenLastNameIsNullOrEmptyOrSpace_ShouldThrowArgumentException(string lastName)
    {
        //arrange
        var calculatorService = new CalculatorService();

        //act & assert
        var methodToBeTested = () => calculatorService.Calculate(ValidFirstName, lastName);

        Assert.Throws<ArgumentException>(() => methodToBeTested());
    }
    
    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void Calculate_WhenFirstNameIsNullOrEmptyOrSpace_ShouldThrowArgumentException(string firstName)
    {
        //arrange
        var calculatorService = new CalculatorService();

        //act & assert
        var methodToBeTested = () => calculatorService.Calculate(firstName, ValidLastName);

        Assert.Throws<ArgumentException>(() => methodToBeTested());
    }

    [Fact]
    public void Calculate_WhenCounterIsOnlyMultiplierOfThree_ShouldReturnFirstName()
    {
        //arrange
        var calculatorService = new CalculatorService();

        //act
        var result = calculatorService.Calculate(ValidFirstName, ValidLastName);

        //assert
        var resultItem = result.First(m => m.Counter == 9);
        Assert.Equal(ValidFirstName, resultItem.Output);
    }

    [Fact]
    public void Calculate_WhenCounterIsOnlyMultiplierOfFive_ShouldReturnLastName()
    {
        //arrange
        var calculatorService = new CalculatorService();

        //act
        var result = calculatorService.Calculate(ValidFirstName, ValidLastName);

        //assert
        var resultItem = result.First(m => m.Counter == 25);
        Assert.Equal(ValidLastName, resultItem.Output);
    }

    [Fact]
    public void Calculate_WhenCounterIsMultiplierOfBothThreeAndFive_ShouldReturnFullTextWithOneSpaceBetweenThem()
    {
        //arrange
        var calculatorService = new CalculatorService();
        var expectedOutput = $"{ValidFirstName} {ValidLastName}";

        //act
        var result = calculatorService.Calculate(ValidFirstName, ValidLastName);

        //assert
        var resultItem = result.First(m => m.Counter == 30);
        Assert.Equal(expectedOutput, resultItem.Output);
    }
}