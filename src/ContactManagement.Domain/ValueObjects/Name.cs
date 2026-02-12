using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Domain.ValueObjects;

public sealed class Name
{
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    public static Name Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ValidationException("Invalid name");

        return new Name(value);
    }

    public override int GetHashCode() => Value.GetHashCode();
}
