using AutoMapper;
using JetBrains.Annotations;

namespace NameCalculator.Calculator.Mapping;

[UsedImplicitly]
public class CalculatorAutomapperProfile : Profile
{
    public CalculatorAutomapperProfile()
    {
        CreateMap<Result, ResultDto>();
    }
}