using Serilog;
using Serilog.Sinks.Fluentd;

namespace Reminder.Presentation.Infrastructure.Extensions;

public static class LogExtensions
{
    public static void ConfigureLogger(this WebApplicationBuilder builder)
    {
        builder.Logging.ClearProviders();
        builder.Host.UseSerilog((builderContext, config) =>
        {
            config.ReadFrom.Configuration(builderContext.Configuration)
                           .Enrich.FromLogContext()
                           .Enrich.WithProperty("service_name", "Reminder")
                           .WriteTo.Fluentd(new FluentdSinkOptions("http://127.0.0.1", 24224, "fluentd"));


        });
    }
}