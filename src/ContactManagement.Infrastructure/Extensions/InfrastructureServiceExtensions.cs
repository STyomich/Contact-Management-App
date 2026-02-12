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
          .Replace("$SQLSERVER_HOST", Environment.GetEnvironmentVariable("SQLSERVER_HOST"))
          .Replace("$SQLSERVER_PASSWORD", Environment.GetEnvironmentVariable("SQLSERVER_PASSWORD"))
          .Replace("$SQLSERVER_DATABASE", Environment.GetEnvironmentVariable("SQLSERVER_DATABASE"))
          .Replace("$SQLSERVER_PORT", Environment.GetEnvironmentVariable("SQLSERVER_PORT"))
          .Replace("$SQLSERVER_USER", Environment.GetEnvironmentVariable("SQLSERVER_USER"));

        services.AddDbContext<ContactManagementDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString);
            });

        services.AddSingleton<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IContactsRepository, ContactsRepository>();
        return services;
    }
}
