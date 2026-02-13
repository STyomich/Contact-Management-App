using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Repositories;
using ContactManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Infrastructure.Repositories;

public sealed class ContactsRepository(ContactManagementDbContext context) : IContactsRepository
{
    private readonly ContactManagementDbContext _context = context;

    public async Task AddAsync(Contact contact, CancellationToken cancellationToken = default)
    {
        await _context.Contacts.AddAsync(contact, cancellationToken);
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var contact = await GetByIdAsync(id, cancellationToken);
        if (contact != null)
        {
            _context.Contacts.Remove(contact);
        }
    }

    public async Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Contacts.ToListAsync(cancellationToken);
    }

    public async Task<IEnumerable<Contact>> GetByDateOfBirthAsync(DateTime dateOfBirth, CancellationToken cancellationToken = default)
    {
        return await _context.Contacts.Where(c => c.DateOfBirth.Value == dateOfBirth).ToListAsync(cancellationToken);
    }

    public async Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Contacts.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Contact>> GetByNameAsync(string name, CancellationToken cancellationToken = default)
    {
        return await _context.Contacts.Where(c => c.Name.Value == name).ToListAsync(cancellationToken);
    }

    public async Task<bool> IsExistsByPhoneAsync(string phone, CancellationToken cancellationToken = default)
    {
        return await _context.Contacts.AnyAsync(c => c.Phone.Value == phone, cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<int> UpdateAsync(Contact contact, CancellationToken cancellationToken = default)
    {
        _context.Contacts.Update(contact);
        return await _context.SaveChangesAsync(cancellationToken);
    }
}
