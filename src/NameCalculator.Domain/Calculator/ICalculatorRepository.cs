using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.Domain.Repositories;

namespace NameCalculator.Calculator;

public interface ICalculatorRepository : IBasicRepository<Result, Guid>
{
    Task CalculateAsync([NotNull] string firstName, [NotNull] string lastName, Guid operationFlag);
    
    Task<List<Result>> GetResultsByOperationFlagAsync(Guid operationFlag);
}