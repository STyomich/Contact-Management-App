using Microsoft.EntityFrameworkCore;

namespace ContactManagement.Infrastructure.DbContext;

public sealed class ContactManagementDbContext(DbContextOptions<ContactManagementDbContext> options) : Microsoft.EntityFrameworkCore.DbContext(options)
{
    public DbSet<Domain.Entities.Contact> Contacts { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContactManagementDbContext).Assembly);
    }
}
