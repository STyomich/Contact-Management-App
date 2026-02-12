using ContactManagement.Application.DTO.Contacts;
using FluentValidation;

namespace ContactManagement.Application.Validation;


/// <summary>
/// Validator for AddContactRequest to ensure that the input data is valid before processing.
/// This includes checks for required fields, valid formats, and logical constraints (e.g., Date of Birth must be in the past).
/// The validation rules are defined using FluentValidation, which provides a fluent interface for building validation rules and custom error messages.
/// 
/// * This just a simple example, but during development I will prefere Domain layer validatio with ValueObjects. If its touches checking data for uniqueness, it will be in bussines logic layer, because it needs to check database for existing data. But if its just checking format of data, it will be in Domain layer with ValueObjects.
/// </summary>
public sealed class AddContactRequestValidator : AbstractValidator<AddContactRequest>
{
    public AddContactRequestValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(50)
            .WithMessage("Name must not exceed 50 characters.");

        RuleFor(x => x.DateOfBirth)
            .LessThan(DateTime.Now)
            .WithMessage("Date of Birth must be in the past.");

        RuleFor(x => x.Phone)
            .NotEmpty()
            .WithMessage("Phone number is required.")
            .Matches(@"^\+?[1-9]\d{1,14}$")
            .MaximumLength(20)
            .WithMessage("Phone number must be in a valid format.");

        RuleFor(x => x.Salary)
            .GreaterThanOrEqualTo(0)
            .WithMessage("Salary must be a non-negative value.");
    }
}