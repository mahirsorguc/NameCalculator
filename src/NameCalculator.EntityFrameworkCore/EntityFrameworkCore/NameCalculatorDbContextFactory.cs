using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace NameCalculator.EntityFrameworkCore;

/* This class is needed for EF Core console commands
 * (like Add-Migration and Update-Database commands) */
public class NameCalculatorDbContextFactory : IDesignTimeDbContextFactory<NameCalculatorDbContext>
{
    public NameCalculatorDbContext CreateDbContext(string[] args)
    {
        NameCalculatorEfCoreEntityExtensionMappings.Configure();

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<NameCalculatorDbContext>()
            .UseSqlServer(configuration.GetConnectionString("Default"));

        return new NameCalculatorDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../NameCalculator.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
