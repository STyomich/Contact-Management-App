using ContactManagement.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ContactManagement.Infrastructure.Persistence;

public class ContactManagementeDbContextFactory
    : IDesignTimeDbContextFactory<ContactManagementDbContext>
{
    public ContactManagementDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ContactManagementDbContext>();

        // LOCAL DEV connection (used ONLY for migrations)
        var connectionString =
            "Server=localhost,1433;Database=ContactManagement;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;"; // temporarilly harcoded

        optionsBuilder.UseSqlServer(connectionString);

        return new ContactManagementDbContext(optionsBuilder.Options);
    }
}
