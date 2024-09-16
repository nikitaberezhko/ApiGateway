using Serilog;

namespace WebApi.Extensions;

public static class BuilderCollectionExtensions
{
    public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .CreateLogger();
        builder.Host.UseSerilog();

        return builder;
    }
}