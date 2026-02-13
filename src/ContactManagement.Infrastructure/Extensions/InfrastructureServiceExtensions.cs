using ContactManagement.Domain.Interfaces;
using ContactManagement.Domain.Repositories;
using ContactManagement.Infrastructure.Data;
using ContactManagement.Infrastructure.DbContext;
using ContactManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagement.Infrastructure.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        string connectionStringTemplate = configuration.GetConnectionString("SqlServerConnection")!;
        string connectionString = connectionStringTemplate
            .Replace("$MSSQL_HOST", Environment.GetEnvironmentVariable("MSSQL_HOST"))
            .Replace("$MSSQL_PORT", Environment.GetEnvironmentVariable("MSSQL_PORT"))
            .Replace("$MSSQL_DATABASE", Environment.GetEnvironmentVariable("MSSQL_DATABASE"))
            .Replace("$MSSQL_USER", Environment.GetEnvironmentVariable("MSSQL_USER"))
            .Replace("$MSSQL_PASSWORD", Environment.GetEnvironmentVariable("MSSQL_PASSWORD"));


        services.AddDbContext<ContactManagementDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IContactsRepository, ContactsRepository>();
        return services;
    }
}
