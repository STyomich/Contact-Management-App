using ContactManagement.Application.DTO.Contacts;
using ContactManagement.Application.Interfaces;
using ContactManagement.Domain.Entities;
using ContactManagement.Domain.Interfaces;
using ContactManagement.Domain.ValueObjects;

namespace ContactManagement.Application.Services;

public class ContactsService(IUnitOfWork unitOfWork) : IContactsService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task AddContactAsync(AddContactRequest request, CancellationToken cancellationToken)
    {
        if (await _unitOfWork.ContactsRepository.IsExistsByPhoneAsync(request.Phone, cancellationToken))
            throw new InvalidOperationException("A contact with the same phone number already exists.");

        var contact = new Contact
        (
            id: Guid.NewGuid(),
            name: Name.Create(request.Name).Value,
            dateOfBirth: DateOfBirth.Create(request.DateOfBirth).Value,
            married: request.Married,
            phone: Phone.Create(request.Phone).Value,
            salary: Salary.Create(request.Salary).Value
        );

        await _unitOfWork.ContactsRepository.AddAsync(contact, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteContactAsync(Guid id, CancellationToken cancellationToken)
    {
        await _unitOfWork.ContactsRepository.DeleteAsync(id, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<IEnumerable<ContactListItemDto>> GetAllContactsAsync(CancellationToken cancellationToken)
    {
        var contacts = await _unitOfWork.ContactsRepository.GetAllAsync(cancellationToken);
        return contacts.Select(c => new ContactListItemDto(
            c.Id,
            c.Name.Value,
            c.DateOfBirth.Value,
            c.Married,
            c.Phone.Value,
            c.Salary.Value
        ));
    }

    public async Task<ContactDto?> GetContactByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.ContactsRepository.GetByIdAsync(id, cancellationToken);
        if (contact == null)
            return null;

        return new ContactDto(
            contact.Id,
            contact.Name.Value,
            contact.DateOfBirth.Value,
            contact.Married,
            contact.Phone.Value,
            contact.Salary.Value
        );
    }

    public async Task UpdateContactAsync(Guid id, UpdateContactRequest request, CancellationToken cancellationToken)
    {
        var contact = await _unitOfWork.ContactsRepository.GetByIdAsync(id, cancellationToken);
        if (contact == null)
            throw new InvalidOperationException("Contact not found.");

        contact.UpdateContact(
            name: Name.Create(request.Name).Value,
            dateOfBirth: DateOfBirth.Create(request.DateOfBirth).Value,
            married: request.Married,
            phone: Phone.Create(request.Phone).Value,
            salary: Salary.Create(request.Salary).Value
        );

        // TODO: Consider adding a check for duplicate phone numbers when updating the contact's phone number.

        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
