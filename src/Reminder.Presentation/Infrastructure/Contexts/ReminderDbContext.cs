using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using Reminder.Presentation.Models;

namespace Reminder.Presentation.Infrastructure.Contexts;

public sealed class ReminderDbContext(DbContextOptions<ReminderDbContext> options) : DbContext(options)
{
    public DbSet<CatalogStockReminder> CatalogStockReminders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<CatalogStockReminder>().ToCollection("catalog_stock_reminders");
    }
}