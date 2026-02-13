
using ContactManagement.Application.DTO.Contacts;
using Microsoft.AspNetCore.Http;

namespace ContactManagement.Application.Interfaces;

public interface IContactsService
{
    Task AddContactAsync(AddContactRequest request, CancellationToken cancellationToken);

    Task DeleteContactAsync(Guid id, CancellationToken cancellationToken);

    Task UpdateContactAsync(Guid id, UpdateContactRequest request, CancellationToken cancellationToken);

    Task<ContactDto?> GetContactByIdAsync(Guid id, CancellationToken cancellationToken);

    Task<IEnumerable<ContactListItemDto>> GetAllContactsAsync(CancellationToken cancellationToken);

    Task ProcessCsvFileAsync(IFormFile csvFile, CancellationToken cancellationToken);
}
