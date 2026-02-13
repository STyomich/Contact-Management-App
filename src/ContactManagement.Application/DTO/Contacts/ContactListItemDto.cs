namespace ContactManagement.Application.DTO.Contacts;

public sealed record ContactListItemDto(
    Guid Id,
    string Name,
    DateTime DateOfBirth,
    bool Married,
    string Phone,
    decimal Salary
);
