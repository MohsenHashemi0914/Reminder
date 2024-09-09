using Reminder.Presentation.Infrastructure.Enums;

namespace Reminder.Presentation.Infrastructure.IntegrationEvents;

public record CatalogItemAvailableNotificationEvent(ICollection<CatalogItemAvailableNotificationEventItem> Items);

public record CatalogItemAvailableNotificationEventItem(Guid UserId, string Message, NotificationChannel Channel);