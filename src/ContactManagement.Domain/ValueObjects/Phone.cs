using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Domain.ValueObjects;

public sealed class Phone
{
    public string Value { get; }

    private Phone(string value)
    {
        Value = value;
    }

    public static Phone Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Invalid phone number.");

        if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\+?[1-9]\d{1,14}$"))
            throw new ValidationException("Phone number must be in E.164 format.");

        return new Phone(value);
    }

    public override int GetHashCode() => Value.GetHashCode();
}
