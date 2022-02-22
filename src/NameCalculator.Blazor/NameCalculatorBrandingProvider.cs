using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace NameCalculator.Blazor;

[Dependency(ReplaceServices = true)]
public class NameCalculatorBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "NameCalculator";
}
