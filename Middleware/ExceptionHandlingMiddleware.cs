using System.Net;
using EmployeeManagerAPI.Exceptions;

namespace EmployeeManagerAPI.Middleware;

public class ExceptionHandlingMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (EmployeeNotFoundException e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsJsonAsync(e.Message);
        }
        catch (DomainBaseException e) when (e is DaysWorkedOutOfRangeException ||
                                            e is VacationDaysUsedExceedsAccumulatedException)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsJsonAsync(e.Message);
        }
        catch (Exception e)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            await context.Response.WriteAsJsonAsync(e.Message);
        }
    }
}