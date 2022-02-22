using System.Threading.Tasks;

namespace NameCalculator.Data;

public interface INameCalculatorDbSchemaMigrator
{
    Task MigrateAsync();
}
