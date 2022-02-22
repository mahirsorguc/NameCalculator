using NameCalculator.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace NameCalculator;

[DependsOn(
    typeof(NameCalculatorEntityFrameworkCoreTestModule)
    )]
public class NameCalculatorDomainTestModule : AbpModule
{

}
