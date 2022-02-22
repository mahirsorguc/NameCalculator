using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameCalculator.Calculator;
using NameCalculator.Console.Helpers;
using Serilog;
using Volo.Abp;

namespace NameCalculator.Console;

public class ConsoleHostedService : IHostedService
{
    private readonly IConfiguration _configuration;
    private readonly IHostEnvironment _hostEnvironment;
    private IAbpApplicationWithInternalServiceProvider _abpApplication;

    public ConsoleHostedService(IConfiguration configuration, IHostEnvironment hostEnvironment)
    {
        _configuration = configuration;
        _hostEnvironment = hostEnvironment;
    }

    private async Task InitializeTheAppAsync()
    {
        _abpApplication = await AbpApplicationFactory.CreateAsync<ConsoleModule>(options =>
        {
            options.Services.ReplaceConfiguration(_configuration);
            options.Services.AddSingleton(_hostEnvironment);

            options.UseAutofac();
            options.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog());
        });

        await _abpApplication.InitializeAsync();
    }
    
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await InitializeTheAppAsync();

        await Run();
    }

    private async Task Run()
    {
        var selectedCalculationType = GetCalculationTypeSelection();

        var firstName = UserDataRetrieverHelper.GetUserInput("First name : ");
        var lastName = UserDataRetrieverHelper.GetUserInput("Last name : ");

        List<ResultDto> results;

        switch (selectedCalculationType)
        {
            case 1:
            {
                var calculatorService = _abpApplication.ServiceProvider.GetRequiredService<ICalculatorService>();
                results = calculatorService.Calculate(firstName, lastName);
                break;
            }
            case 2:
            {
                var calculatorAppService = _abpApplication.ServiceProvider.GetRequiredService<ICalculatorAppService>();
                results = await calculatorAppService.CalculateAsync(firstName, lastName);
                break;
            }
            default:
                throw new NotImplementedException();
        }

        foreach (var resultDto in results)
        {
            System.Console.WriteLine(resultDto.Output);
        }
    }


    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await _abpApplication.ShutdownAsync();
    }

    private static int GetCalculationTypeSelection()
    {
        var selection = 0;
        System.Console.WriteLine("1-) For C# calculation");
        System.Console.WriteLine("2-) For stored procedure calculation");

        while (selection == 0)
        {
            var calculationTypeSelectionUserInput = UserDataRetrieverHelper.GetUserInput("Type your selection : ");

            var isInteger = int.TryParse(calculationTypeSelectionUserInput, out var calculationTypeSelection);

            if (!isInteger)
            {
                continue;
            }

            if (calculationTypeSelection is 1 or 2)
            {
                selection = calculationTypeSelection;
            }
        }

        return selection;
    }
}