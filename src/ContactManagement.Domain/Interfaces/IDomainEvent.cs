namespace ContactManagement.Domain.Interfaces;

/// <summary>
/// Simple domain event interface for raising event in domain layer.
/// </summary>
public interface IDomainEvent
{
    DateTime OccurredOnUtc { get; }
}
