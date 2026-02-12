using ContactManagement.Domain.Primitives;
using ContactManagement.Domain.ValueObjects;

namespace ContactManagement.Domain.Entities;

public sealed class Contact : AggregateRoot
{
    public Guid Id { get; private set; }
    public Name Name { get; private set; }
    public DateOfBirth DateOfBirth { get; private set; }
    public bool Married { get; private set; }
    public Phone Phone { get; private set; }
    public Salary Salary { get; private set; }

    private Contact() { } // for ORM

    public Contact(Guid id, string name, DateTime dateOfBirth, bool married, string phone, decimal salary)
    {
        Id = id;
        Name = Name.Create(name);
        DateOfBirth = DateOfBirth.Create(dateOfBirth);
        Married = married;
        Phone = Phone.Create(phone);
        Salary = Salary.Create(salary);
    }

    public void UpdateContact(string name, DateTime dateOfBirth, bool married, string phone, decimal salary)
    {
        Name = Name.Create(name);
        DateOfBirth = DateOfBirth.Create(dateOfBirth);
        Married = married;
        Phone = Phone.Create(phone);
        Salary = Salary.Create(salary);
    }
}
