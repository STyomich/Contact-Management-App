namespace ContactManagement.Application.DTO.Contacts;

public sealed record ContactDto(
    Guid Id,
    string Name,
    DateTime DateOfBirth,
    bool Married,
    string Phone,
    decimal Salary
);
