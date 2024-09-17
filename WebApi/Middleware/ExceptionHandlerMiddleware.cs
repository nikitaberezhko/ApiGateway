using CommonModel.Contracts;
using Refit;

namespace WebApi.Middleware;

public class ExceptionHandlerMiddleware(ILogger<ExceptionHandlerMiddleware> logger) 
    : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (ApiException e)
        {
            logger.LogWarning($"Api Exception: {e.Message}");

            context.Response.Clear();
            context.Response.StatusCode = (int)e.StatusCode;
            context.Response.ContentType = "application/json";
            await context.Response.WriteAsync(e.Content!);
        }
        catch (Exception e)
        {
            logger.LogCritical(e, "Unknown server error");
            
            await InterceptResponseAsync(context,
                "Unknown server error", 
                "Please retry query", 
                StatusCodes.Status500InternalServerError);
        }
    }
    
    private async Task InterceptResponseAsync(HttpContext context,
        string title, 
        string message, 
        int statusCode)
    {
        var response = new CommonResponse<Empty>
        {
            Data = null,
            Error = new Error
            {
                Title = title,
                Message = message,
                StatusCode = statusCode
            }
        };
            
        context.Response.Clear();
        context.Response.StatusCode = statusCode;
        await context.Response.WriteAsJsonAsync(response);
    }
}

record Empty;
