using System.Collections.Generic;
using System.Threading.Tasks;
using Blazorise;
using JetBrains.Annotations;
using NameCalculator.Blazor.Models;
using NameCalculator.Calculator;

namespace NameCalculator.Blazor.Pages;

public partial class Index
{
    [NotNull] private readonly PersonModel _personModel = new();
    [CanBeNull] private List<ResultDto> _results;
    private Validations _validations;

    private async Task OnRunClickedAsync()
    {
        if (await _validations.ValidateAll())
        {
            _results = null;

            _results = await _calculatorAppService.CalculateAsync(_personModel.FirstName, _personModel.LastName);
        }
    }
}