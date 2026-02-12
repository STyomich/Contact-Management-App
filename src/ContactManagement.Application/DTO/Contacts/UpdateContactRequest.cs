namespace ContactManagement.Application.DTO.Contacts;

public sealed record UpdateContactRequest(
    Guid Id,
    string Name,
    DateTime DateOfBirth,
    bool Married,
    string Phone,
    decimal Salary
);
