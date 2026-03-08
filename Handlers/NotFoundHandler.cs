using LibreriaApi.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public sealed class NotFoundExceptionHandler : IExceptionHandler
{

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken ct)
    {
        
        if (exception is not NotFoundException notFound) return false;

        httpContext.Response.StatusCode = StatusCodes.Status404NotFound;

        var problem = new ProblemDetails
        {
            Status = StatusCodes.Status404NotFound,
            Title = "No Existe",
            Detail = notFound.Message,
            Instance = httpContext.Request.Path
        };

        await httpContext.Response.WriteAsJsonAsync(problem, ct);

        return true;
    }
}