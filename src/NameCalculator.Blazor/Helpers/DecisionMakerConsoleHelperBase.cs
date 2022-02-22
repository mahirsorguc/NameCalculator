using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp.DependencyInjection;

namespace NameCalculator.Blazor.Helpers;

[UsedImplicitly]
public abstract class DecisionMakerConsoleHelperBase : ITransientDependency
{
    [CanBeNull] protected string FirstName;
    [CanBeNull] protected string LastName;

    protected void CollectUserdata()
    {
        while (string.IsNullOrEmpty(FirstName))
        {
            Console.Write("Type your first name and press the enter key : ");

            FirstName = Console.ReadLine();
        }

        while (string.IsNullOrEmpty(LastName))
        {
            Console.Write("Type your last name and press the enter key : ");

            LastName = Console.ReadLine();
        }
    }

    public abstract Task Run();
}