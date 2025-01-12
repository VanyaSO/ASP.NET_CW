using System.ComponentModel.DataAnnotations;

namespace lesson_12_11.Models;

public static class PersonValidator
{
    public static ValidationResult CustomValidation(bool value, ValidationContext validationContext)
    {
        if (value)
        {
            return ValidationResult.Success;
        }

        return new ValidationResult("Должен быть видимым");
    }
}