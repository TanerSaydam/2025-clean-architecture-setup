using CleanArhictecture_2025.Application.Employees;
using MediatR;
using TS.Result;

namespace CleanArhictecture_2025.WebAPI.Modules;

public static class EmployeeModule
{
    public static void RegisterEmployeeRoutes(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/employees").WithTags("Employees");

        group.MapPost(string.Empty,
            async (ISender sender, EmployeeCreateCommand request, CancellationToken cancellatioNToken) =>
            {
                var response = await sender.Send(request, cancellatioNToken);
                return response.IsSuccessful ? Results.Ok(response) : Results.InternalServerError(response);
            })
            .Produces<Result<string>>();
    }
}
