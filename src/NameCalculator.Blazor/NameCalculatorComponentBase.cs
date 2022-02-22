using NameCalculator.Localization;
using Volo.Abp.AspNetCore.Components;

namespace NameCalculator.Blazor;

public abstract class NameCalculatorComponentBase : AbpComponentBase
{
    protected NameCalculatorComponentBase()
    {
        LocalizationResource = typeof(NameCalculatorResource);
    }
}
