namespace ContactManagement.Application.DTO.Contacts;

public sealed record AddContactRequest(
    string Name,
    DateTime DateOfBirth,
    bool Married,
    string Phone,
    decimal Salary
);
