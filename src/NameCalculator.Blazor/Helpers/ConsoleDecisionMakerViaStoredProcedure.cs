using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NameCalculator.Calculator;
using Volo.Abp;

namespace NameCalculator.Blazor.Helpers;

public sealed class ConsoleDecisionMakerViaStoredProcedure : DecisionMakerConsoleHelperBase
{
    [NotNull] private readonly ICalculatorAppService _calculatorAppService;

    public ConsoleDecisionMakerViaStoredProcedure([NotNull] ICalculatorAppService calculatorAppService)
    {
        _calculatorAppService = calculatorAppService;
    }

    public override async Task Run()
    {
        CollectUserdata();

        var firstName = Check.NotNullOrEmpty(FirstName, nameof(FirstName));
        var lastName = Check.NotNullOrEmpty(LastName, nameof(LastName));

        var operationFlag = await _calculatorAppService.CalculateAsync(firstName,lastName);

        var results = await _calculatorAppService.GetResultsByOperationFlag(operationFlag);
        
        foreach (var resultDto in results)
        {
            Console.WriteLine(resultDto.Output);
        }
    }
}