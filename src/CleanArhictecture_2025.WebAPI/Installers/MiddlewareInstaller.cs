namespace CleanArhictecture_2025.WebAPI.Installers;

public static class MiddlewareInstaller
{
    public static void AddMiddlewares(this WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseCors(x => x
            .AllowAnyHeader()
            .AllowCredentials()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true));

        app.UseAuthentication();
        
        app.UseAuthorization();

        app.UseResponseCompression();

        app.UseExceptionHandler();
    }
}