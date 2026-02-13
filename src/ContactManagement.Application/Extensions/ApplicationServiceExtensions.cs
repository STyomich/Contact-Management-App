using ContactManagement.Application.Interfaces;
using ContactManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ContactManagement.Application.Extensions;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IContactsService, ContactsService>();
        return services;
    }
}
