using Microsoft.EntityFrameworkCore;
using Reminder.Presentation.Infrastructure.Contexts;

namespace Reminder.Presentation.Infrastructure.Extensions;

public static class DbContextDependencyInjection
{
    public static void AddMongoDb(this IHostApplicationBuilder builder)
    {
        var mongoDbConfig = builder.Configuration.GetSection(MongoDbOptions.SectionName).Get<MongoDbOptions>();

        ArgumentNullException.ThrowIfNull(mongoDbConfig, nameof(MongoDbOptions));

        builder.Services.AddDbContext<ReminderDbContext>(options =>
        {
            options.UseMongoDB(mongoDbConfig.Host, mongoDbConfig.DatabaseName);
        });
    }
}