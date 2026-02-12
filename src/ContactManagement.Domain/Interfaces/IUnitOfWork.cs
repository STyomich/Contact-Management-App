using ContactManagement.Domain.Repositories;

namespace ContactManagement.Domain.Interfaces;

public interface IUnitOfWork
{
    IContactsRepository ContactsRepository { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
