using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NameCalculator.Data;
using Volo.Abp.DependencyInjection;

namespace NameCalculator.EntityFrameworkCore;

public class EntityFrameworkCoreNameCalculatorDbSchemaMigrator
    : INameCalculatorDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreNameCalculatorDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the NameCalculatorDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<NameCalculatorDbContext>()
            .Database
            .MigrateAsync();
    }
}
