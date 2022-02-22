using NameCalculator.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Modularity;

namespace NameCalculator.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(NameCalculatorEntityFrameworkCoreModule),
    typeof(NameCalculatorApplicationContractsModule)
    )]
public class NameCalculatorDbMigratorModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpBackgroundJobOptions>(options => options.IsJobExecutionEnabled = false);
    }
}
