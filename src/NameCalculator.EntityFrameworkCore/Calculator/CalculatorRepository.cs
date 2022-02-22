using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NameCalculator.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NameCalculator.Calculator;

[UsedImplicitly]
public class CalculatorRepository : EfCoreRepository<NameCalculatorDbContext, Result, Guid>,
    ICalculatorRepository
{
    public CalculatorRepository(IDbContextProvider<NameCalculatorDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    public async Task CalculateAsync(string firstName, string lastName, Guid operationFlag)
    {
        Check.NotNullOrEmpty(firstName, nameof(firstName));
        Check.NotNullOrEmpty(lastName, nameof(lastName));
        Check.NotNullOrEmpty(firstName.Trim(), nameof(firstName));
        Check.NotNullOrEmpty(lastName.Trim(), nameof(lastName));

        var firstNameParam = new SqlParameter("@firstText", firstName);
        var lastNameParam = new SqlParameter("@secondText", lastName);
        var operationFlagParam = new SqlParameter("@operationFlag", operationFlag);

        var dbContext = await GetDbContextAsync();

        await dbContext.Database.ExecuteSqlRawAsync(
            $"EXEC [PRC_MakeDecision] @firstText, @secondText, @operationFlag",
            firstNameParam,
            lastNameParam,
            operationFlagParam);
    }

    public async Task<List<Result>> GetResultsByOperationFlagAsync(Guid operationFlag)
    {
        var queryable = await base.GetQueryableAsync();

        var results = await queryable
            .Where(m => m.OperationFlag == operationFlag)
            .OrderBy(m => m.Counter)
            .ToListAsync();

        return results;
    }
}