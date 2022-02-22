using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Application.Services;

namespace NameCalculator.Calculator;

public interface ICalculatorAppService : IApplicationService
{
    Task<List<ResultDto>> CalculateAsync([NotNull] string firstName, [NotNull] string lastName);
}