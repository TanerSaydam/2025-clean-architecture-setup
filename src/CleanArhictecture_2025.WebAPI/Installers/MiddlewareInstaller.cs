namespace CleanArhictecture_2025.WebAPI.Installers;
using CleanArhictecture_2025;
public static class MiddlewareInstaller
{
    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseHttpsRedirection();
        
        app.UseExceptionHandler();

        app.UseCors(x => x
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true));

        app.UseAuthentication();
        
        app.UseAuthorization();
        
        ExtensionsMiddleware.CreateFirstUser(app);

        app.UseResponseCompression();
    }
}