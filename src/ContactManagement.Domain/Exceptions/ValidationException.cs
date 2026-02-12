namespace ContactManagement.Domain.Exceptions;

public class ValidationException : DomainException
{
    public ValidationException(string message) : base("Validation exception in creating of entity.") { }
}
