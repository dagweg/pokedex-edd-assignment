using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pokedex.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (KeyNotFoundException ex)
        {
            var problemDetails = new ProblemDetails
            {
                Title = "Resource not found",
                Detail = ex.Message,
                Status = StatusCodes.Status404NotFound,
                Extensions = { { "traceId", context.TraceIdentifier } },
            };

            context.Response.StatusCode = StatusCodes.Status404NotFound;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
        catch (Exception)
        {
            var problemDetails = new ProblemDetails
            {
                Type = "InternalServerFailure",
                Title = "InternalServer Error",
                Detail = "An internal server error has occured",
                Extensions = { { "traceId", context.TraceIdentifier } },
            };

            context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            await context.Response.WriteAsJsonAsync(problemDetails);
        }
    }
}
