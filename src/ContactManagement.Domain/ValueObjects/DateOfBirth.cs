using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Domain.ValueObjects;

public sealed class DateOfBirth
{
    public DateTime Value { get; }

    private DateOfBirth(DateTime value)
    {
        Value = value;
    }

    public static DateOfBirth Create(DateTime value)
    {
        if (value > DateTime.UtcNow)
            throw new ValidationException("Date of birth cannot be in the future.");

        var age = DateTime.UtcNow.Year - value.Year;
        if (value.Date > DateTime.UtcNow.AddYears(-age))
            age--;

        if (age < 16)
            throw new ValidationException("Age cannot be lower than 16 years.");

        return new DateOfBirth(value);
    }
}
