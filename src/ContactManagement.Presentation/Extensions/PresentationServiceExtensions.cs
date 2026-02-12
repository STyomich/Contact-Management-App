namespace ContactManagement.Presentation.Extensions;

public static class PresentationServiceExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            });
        });

        services.AddControllers();
        services.AddEndpointsApiExplorer();

        services.AddHttpContextAccessor();

        return services;
    }
}
