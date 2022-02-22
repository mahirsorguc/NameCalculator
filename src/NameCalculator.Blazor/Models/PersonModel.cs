namespace NameCalculator.Blazor.Models;

public class PersonModel
{
    private string _firstName;
    private string _lastName;

    public string FirstName
    {
        get => _firstName?.Trim();
        set => _firstName = value?.Trim();
    }

    public string LastName
    {
        get => _lastName?.Trim();
        set => _lastName = value?.Trim();
    }
}