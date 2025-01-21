using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using TS.Result;

namespace CleanArhictecture_2025.WebAPI;

public sealed class ExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        Result<string> errorResult;

        httpContext.Response.ContentType = "application/json";
        httpContext.Response.StatusCode = 500;

        if (exception.GetType() == typeof(ValidationException))
        {
            httpContext.Response.StatusCode = 403;

            errorResult = Result<string>.Failure(403, ((ValidationException)exception).Errors.Select(s => s.PropertyName).ToList());

            await httpContext.Response.WriteAsJsonAsync(errorResult);

            return true;
        }

        errorResult = Result<string>.Failure(exception.Message);

        await httpContext.Response.WriteAsJsonAsync(errorResult);

        return true;
    }
}
