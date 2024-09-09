using Reminder.Presentation.Infrastructure.Enums;

namespace Reminder.Presentation.Infrastructure.IntegrationEvents;

public record CatalogRemindEvent(
    Guid UserId,
    string Slug,
    string Message,
    NotificationChannel Channel);