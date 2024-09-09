using MassTransit;
using Reminder.Presentation.Infrastructure.Contexts;
using Reminder.Presentation.Infrastructure.IntegrationEvents;

namespace Reminder.Presentation.Infrastructure.Consumers;

public class CatalogRemindEventConsumer(ReminderDbContext dbContext) : IConsumer<CatalogRemindEvent>
{
    public async Task Consume(ConsumeContext<CatalogRemindEvent> context)
    {
        var message = context.Message;

        await dbContext.CatalogStockReminders.AddAsync(new()
        {
            Slug = message.Slug,
            UserId = message.UserId,
            Message = message.Message,
            Channel = message.Channel
        }, context.CancellationToken);

        await dbContext.SaveChangesAsync(context.CancellationToken);
    }
}