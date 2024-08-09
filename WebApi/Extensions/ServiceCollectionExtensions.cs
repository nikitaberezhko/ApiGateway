using Asp.Versioning;
using Infrastructure.RefitClients;
using Infrastructure.Settings;
using Microsoft.OpenApi.Models;
using Refit;
using WebApi.Middleware;

namespace WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection ConfigureApiVersioning(
        this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }

    public static IServiceCollection ConfigureRefitClients(
        this IServiceCollection services, IConfiguration configuration)
    {
        var refitSettings = configuration.GetSection("RefitClientsSettings")
            .Get<RefitClientsSettings>();
        
        services.AddRefitClient<IOrderApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.OrderApiUrl));
        services.AddRefitClient<IIdentityApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.IdentityApiUrl));
        services.AddRefitClient<IContainerApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.ContainerApiUrl));
        services.AddRefitClient<IFinanceApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.FinanceApiUrl));

        return services;
    }
    
    public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlerMiddleware>();
        
        return services;
    }
    
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(c =>
        {
            c.MapType<DateOnly>(() => new OpenApiSchema
            {
                Type = "string",
                Format = "date",
            });
        });

        return services;
    }
}