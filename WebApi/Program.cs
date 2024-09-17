using SerilogTracing;
using WebApi.Extensions;
using WebApi.Middleware;

namespace WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var services = builder.Services;
        using var listener = new ActivityListenerConfiguration()
            .TraceToSharedLogger();

        services.AddControllers();
        
        // Extensions
        services.ConfigureApiVersioning();
        services.ConfigureRefitClients(builder.Configuration);
        services.AddSwagger();
        services.AddExceptionHandling();
        services.AddCompositeService();
        services.AddMappers();
        services.AddTelemetry();
        services.ConfigureSerilogAndZipkinTracing();
        

        var app = builder.Build();
        
        app.UseMiddleware<ExceptionHandlerMiddleware>();
        
        app.UseSwagger();
        app.UseSwaggerUI();

        app.UseHttpsRedirection();

        app.MapPrometheusScrapingEndpoint();
        
        app.MapControllers();
        app.Run();
    }
}