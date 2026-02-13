using ContactManagement.Domain.Entities;

namespace ContactManagement.Domain.Repositories;

public interface IContactsRepository
{
    Task AddAsync(Contact contact, CancellationToken cancellationToken = default);
    Task<int> UpdateAsync(Contact contact, CancellationToken cancellationToken = default);
    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Contact?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Contact>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<IEnumerable<Contact>> GetByNameAsync(string name, CancellationToken cancellationToken = default);
    Task<IEnumerable<Contact>> GetByDateOfBirthAsync(DateTime dateOfBirth, CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task<bool> IsExistsByPhoneAsync(string phone, CancellationToken cancellationToken = default);
}