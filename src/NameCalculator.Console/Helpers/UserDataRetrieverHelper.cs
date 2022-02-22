using JetBrains.Annotations;

namespace NameCalculator.Console.Helpers;

public static class UserDataRetrieverHelper
{
    internal static string GetUserInput([NotNull] string message)
    {
        while (true)
        {
            System.Console.Write(message);

            var input = System.Console.ReadLine();

            if (!string.IsNullOrEmpty(input))
            {
                return input;
            }
        }
    }
}