using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace NameCalculator.Data;

/* This is used if database provider does't define
 * INameCalculatorDbSchemaMigrator implementation.
 */
public class NullNameCalculatorDbSchemaMigrator : INameCalculatorDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
