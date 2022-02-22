using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Guids;

namespace NameCalculator.Calculator;

[UsedImplicitly]
public class CalculatorAppService : NameCalculatorAppService, ICalculatorAppService
{
    [NotNull] private readonly ICalculatorRepository _calculatorRepository;
    [NotNull] private readonly SequentialGuidGenerator _sequentialGuidGenerator;

    public CalculatorAppService([NotNull] ICalculatorRepository calculatorRepository,
        [NotNull] SequentialGuidGenerator sequentialGuidGenerator)
    {
        _sequentialGuidGenerator = sequentialGuidGenerator;
        _calculatorRepository = Check.NotNull(calculatorRepository, nameof(calculatorRepository));
    }

    public async Task<List<ResultDto>> CalculateAsync(string firstName, string lastName)
    {
        Check.NotNullOrEmpty(firstName, nameof(firstName));
        Check.NotNullOrEmpty(lastName, nameof(lastName));
        Check.NotNullOrEmpty(firstName.Trim(), nameof(firstName));
        Check.NotNullOrEmpty(lastName.Trim(), nameof(lastName));

        var operationFlag = _sequentialGuidGenerator.Create();

        await _calculatorRepository.CalculateAsync(firstName, lastName, operationFlag);

        var result = await GetResultsByOperationFlag(operationFlag);

        return result;
    }

    private async Task<List<ResultDto>> GetResultsByOperationFlag(Guid operationFlag)
    {
        var results = await _calculatorRepository.GetResultsByOperationFlagAsync(operationFlag);

        var resultsDto = ObjectMapper.Map<List<Result>, List<ResultDto>>(results);

        return resultsDto;
    }
}