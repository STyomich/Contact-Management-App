using ContactManagement.Domain.Entities;
using ContactManagement.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactManagement.Infrastructure.Data.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);
        builder.OwnsOne(u => u.Name, e =>
        {
            e.Property(p => p.Value)
             .HasColumnName("Name")
             .IsRequired();
        });

        builder.OwnsOne(u => u.DateOfBirth, e =>
        {
            e.Property(p => p.Value)
             .HasColumnName("DateOfBirth")
             .IsRequired();
        });

        builder.Property(c => c.Married).IsRequired();

        builder.OwnsOne(u => u.Phone, e =>
        {
            e.Property(p => p.Value)
             .HasColumnName("Phone")
             .IsRequired();
        });

        builder.Property(c => c.Salary)
            .HasConversion(
            dob => dob.Value,
            value => Salary.Create(value));
    }
}
