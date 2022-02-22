using Volo.Abp.Modularity;

namespace NameCalculator;

[DependsOn(
    typeof(NameCalculatorApplicationModule),
    typeof(NameCalculatorDomainTestModule)
    )]
public class NameCalculatorApplicationTestModule : AbpModule
{

}
