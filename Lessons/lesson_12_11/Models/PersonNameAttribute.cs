using System.ComponentModel.DataAnnotations;

namespace lesson_12_11.Models;

public class PersonNameAttribute : ValidationAttribute
{
    private string[] names;

    public PersonNameAttribute(string[] names)
    {
        this.names = names;
    }

    public override bool IsValid(object? value)
    {
        if (value != null && !names.Contains(value.ToString()))
        {
            return true;
        }

        return false;
    }
}