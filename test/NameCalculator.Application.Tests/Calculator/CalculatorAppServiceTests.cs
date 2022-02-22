using System;
using System.Threading.Tasks;
using Xunit;

namespace NameCalculator.Calculator;

public class CalculatorAppServiceTests : NameCalculatorApplicationTestBase
{
    private const string ValidFirstName = "John";
    private const string ValidLastName = "Doe";

    private readonly ICalculatorAppService _calculatorAppService;

    public CalculatorAppServiceTests()
    {
        _calculatorAppService = GetService<ICalculatorAppService>();
    }

    [Fact]
    public async Task CalculateAsync_WhenAllParametersAreValid_ShouldSucceeded()
    {
        //This one will be failed due to in memory testing doesn't support SP.
        
        //arrange
        const int expectedNumberOfItems = 100;
        
        //act
        var result =  await _calculatorAppService.CalculateAsync(ValidFirstName, ValidLastName);
        
        //assert
        Assert.NotEmpty(result);
        Assert.NotNull(result);
        Assert.Equal(expectedNumberOfItems,result.Count);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void CalculateAsync_WhenFirstNameIsNullOrEmptyOrSpace_ShouldThrowArgumentException(string firstName)
    {
        //act
        var methodToBeTested = async () => await _calculatorAppService.CalculateAsync(firstName, ValidLastName);

        //assert
        Assert.ThrowsAsync<ArgumentException>(methodToBeTested);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("")]
    [InlineData(null)]
    public void CalculateAsync_WhenLastNameIsNullOrEmptyOrSpace_ShouldThrowArgumentException(string lastName)
    {
        //act
        var methodToBeTested = async () => await _calculatorAppService.CalculateAsync(ValidFirstName, lastName);

        //assert
        Assert.ThrowsAsync<ArgumentException>(methodToBeTested);
    }
}