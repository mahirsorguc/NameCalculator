using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using NameCalculator.Calculator;
using Volo.Abp;

namespace NameCalculator.Blazor.Helpers;

public sealed class ConsoleDecisionMakerViaDotNet : DecisionMakerConsoleHelperBase
{
    [NotNull] private readonly ICalculatorService _calculatorService;

    public ConsoleDecisionMakerViaDotNet([NotNull] ICalculatorService calculatorService)
    {
        _calculatorService = calculatorService;
    }

    public override Task Run()
    {
        CollectUserdata();

        var firstName = Check.NotNullOrEmpty(FirstName, nameof(FirstName));
        var lastName = Check.NotNullOrEmpty(LastName, nameof(LastName));

        for (var i = 1; i < 101; i++)
        {
            var output = _calculatorService.Calculate(i, firstName, lastName);

            Console.WriteLine(output);
        }

        return Task.CompletedTask;
    }
}