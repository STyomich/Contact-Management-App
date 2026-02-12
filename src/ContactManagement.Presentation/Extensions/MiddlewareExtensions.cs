namespace ContactManagement.Presentation.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseCustomMiddlewares(this IApplicationBuilder app)
    {
        app.UseCors("AllowAll");
        app.UseAuthorization();
        return app;
    }
}
