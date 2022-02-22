using JetBrains.Annotations;

namespace NameCalculator.Calculator;

public interface ICalculatorService
{
    List<ResultDto> Calculate([NotNull] string firstName, [NotNull] string lastName);
}