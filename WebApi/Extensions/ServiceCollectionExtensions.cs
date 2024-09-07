using Asp.Versioning;
using Infrastructure.RefitClients;
using Infrastructure.Settings;
using Microsoft.OpenApi.Models;
using OpenTelemetry.Metrics;
using Refit;
using Services.Mapper;
using Services.Services;
using Services.Services.Interfaces;
using WebApi.Mapper;
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
    
    public static IServiceCollection AddTelemetry(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .WithMetrics(builder =>
            {
                builder.AddPrometheusExporter();

                builder.AddMeter("Microsoft.AspNetCore.Hosting",
                    "Microsoft.AspNetCore.Server.Kestrel");
                builder.AddView("http.server.request.duration",
                    new ExplicitBucketHistogramConfiguration
                    {
                        Boundaries = [ 0, 0.005, 0.01, 0.025, 0.05,
                            0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ]
                    });
            });
        
        return services;
    }

    public static IServiceCollection AddCompositeService(this IServiceCollection services)
    {
        services.AddScoped<ICompositeContainerFacade, CompositeContainerFacade>();
        
        return services;
    }

    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ServiceMappingProfile),
            typeof(ApiMappingProfile));
        
        return services;
    }

    public static IServiceCollection ConfigureRefitClients(
        this IServiceCollection services, IConfiguration configuration)
    {
        var refitSettings = configuration.GetSection("RefitClientsSettings")
            .Get<RefitClientsSettings>();
        
        services.AddRefitClient<IIdentityApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.IdentityApiUrl));
        services.AddRefitClient<IOrderApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.OrderApiUrl));
        services.AddRefitClient<IContainerApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.ContainerApiUrl));
        services.AddRefitClient<IFinanceApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.FinanceApiUrl));
        services.AddRefitClient<IHubApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.HubApiUrl));
        services.AddRefitClient<ILogisticApi>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri(refitSettings!.LogisticApiUrl));

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