
using ContactManagement.Domain.Interfaces;
using ContactManagement.Domain.Repositories;
using ContactManagement.Infrastructure.DbContext;
using ContactManagement.Infrastructure.Repositories;

namespace ContactManagement.Infrastructure.Data;

public class UnitOfWork(ContactManagementDbContext context) : IUnitOfWork
{
    private readonly ContactManagementDbContext _context = context;

    private IContactsRepository? _contactsRepository;

    public IContactsRepository ContactsRepository
    {
        get
        {
            _contactsRepository ??= new ContactsRepository(_context);

            return _contactsRepository;
        }
    }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken) => _context.SaveChangesAsync(cancellationToken);
}
