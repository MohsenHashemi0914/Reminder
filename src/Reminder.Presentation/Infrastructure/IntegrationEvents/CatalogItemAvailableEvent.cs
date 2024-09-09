namespace Reminder.Presentation.Infrastructure.IntegrationEvents;

public record CatalogItemAvailableEvent(ICollection<string> Slugs);