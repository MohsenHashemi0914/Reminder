using MassTransit;
using Reminder.Presentation.Infrastructure.Extensions;
using Reminder.Presentation.Infrastructure.IntegrationEvents;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.AddMongoDb();
builder.ConfigureBroker();
builder.ConfigureLogger();

var app = builder.Build();

app.MapGet("/", async (IPublishEndpoint publisher) =>
{
    var consumer = new CatalogItemAvailableEvent(new List<string>());
    await publisher.Publish(consumer);
});

app.Run();