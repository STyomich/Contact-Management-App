using ContactManagement.Domain.Interfaces;

namespace ContactManagement.Domain.Primitives;

/// <summary>
/// Base class for aggregate roots in the domain model. An aggregate root is an entity that serves as the entry point for a cluster of related entities and value objects. It is responsible for maintaining the integrity of the aggregate and enforcing business rules. The AggregateRoot class provides a mechanism for raising domain events, which can be used to notify other parts of the system about changes to the aggregate.
/// </summary>
public abstract class AggregateRoot
{
    private readonly List<IDomainEvent> _domainEvents = [];

    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents;

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
        => _domainEvents.Add(domainEvent);

    public void ClearDomainEvents()
        => _domainEvents.Clear();
}
