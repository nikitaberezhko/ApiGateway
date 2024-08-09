using WebApi.Extensions;
using WebApi.Middleware;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;

        services.AddControllers();
        
        // Extensions
        services.ConfigureApiVersioning();
        services.ConfigureRefitClients(builder.Configuration);
        services.AddSwagger();
        services.AddExceptionHandling();
        
        

        var app = builder.Build();
        
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapControllers();
        app.Run();
    }
}