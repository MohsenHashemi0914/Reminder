using MassTransit;
using Microsoft.EntityFrameworkCore;
using Reminder.Presentation.Infrastructure.Contexts;
using Reminder.Presentation.Infrastructure.IntegrationEvents;

namespace Reminder.Presentation.Infrastructure.Consumers;

public class CatalogItemAvailableEventConsumer(ReminderDbContext dbContext,
    ILogger<CatalogItemAvailableEventConsumer> logger,
    IPublishEndpoint publishEndpoint) : IConsumer<CatalogItemAvailableEvent>
{
    private readonly ILogger<CatalogItemAvailableEventConsumer> _logger = logger;

    public async Task Consume(ConsumeContext<CatalogItemAvailableEvent> context)
    {
        var slugs = context.Message.Slugs;

        if (slugs.Count is 0)
        {
            _logger.LogInformation("{0} is empty", nameof(slugs));
        }

        var eventItems = await dbContext.CatalogStockReminders.AsNoTracking()
            .Where(x => slugs.Contains(x.Slug))
            .Select(x => new CatalogItemAvailableNotificationEventItem(x.UserId, x.Message, x.Channel))
            .ToListAsync(context.CancellationToken);

        var @event = new CatalogItemAvailableNotificationEvent(eventItems);
        await publishEndpoint.Publish(@event, context.CancellationToken);
    }
}