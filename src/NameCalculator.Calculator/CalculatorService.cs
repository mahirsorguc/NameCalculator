using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.DependencyInjection;

namespace NameCalculator.Calculator;

[UsedImplicitly]
public class CalculatorService : ICalculatorService, ITransientDependency
{
    private const int FirstMultiplierFactor = 3;
    private const int SecondMultiplierFactor = 5;
    private const int LcmFactor = FirstMultiplierFactor * SecondMultiplierFactor;

    public List<ResultDto> Calculate(string firstName, string lastName)
    {
        Check.NotNullOrEmpty(firstName, nameof(firstName));
        Check.NotNullOrEmpty(lastName, nameof(lastName));
        Check.NotNullOrEmpty(firstName.Trim(), nameof(firstName));
        Check.NotNullOrEmpty(lastName.Trim(), nameof(lastName));

        var output = CalculateInternal(firstName, lastName).OrderBy(m => m.Counter).ToList();

        return output;
    }

    private static ResultDto MakeDecision(int number, string firstName, string lastName)
    {
        if (number % LcmFactor == 0)
        {
            return new ResultDto { Counter = number, Output = $"{firstName} {lastName}" };
        }

        if (number % SecondMultiplierFactor == 0)
        {
            return new ResultDto { Counter = number, Output = lastName };
        }

        return number % FirstMultiplierFactor == 0
            ? new ResultDto { Counter = number, Output = firstName }
            : new ResultDto { Counter = number, Output = Convert.ToString(number) };
    }

    private static IEnumerable<ResultDto> CalculateInternal(string firstName, string lastName)
    {
        for (var counter = 1; counter < 101; counter++)
        {
            yield return MakeDecision(counter, firstName, lastName);
        }
    }
}