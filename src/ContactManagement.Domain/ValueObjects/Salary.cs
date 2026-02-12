using System.ComponentModel.DataAnnotations;

namespace ContactManagement.Domain.ValueObjects;

public sealed class Salary
{
    public decimal Value { get; }

    private Salary(decimal value)
    {
        Value = value;
    }

    public static Salary Create(decimal value)
    {
        if (value < 0)
            throw new ValidationException("Salary cannot be negative.");

        return new Salary(value);
    }
}
