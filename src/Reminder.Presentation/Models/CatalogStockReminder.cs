using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using Reminder.Presentation.Infrastructure.Enums;

namespace Reminder.Presentation.Models;

[Collection("catalog_stock_reminders")]
public sealed class CatalogStockReminder
{
    public ObjectId Id { get; set; }
    public required Guid UserId { get; set; }
    public required string Slug { get; set; }
    public required string Message { get; set; }
    public required NotificationChannel Channel { get; set; }
}