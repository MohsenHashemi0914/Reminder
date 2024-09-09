namespace Reminder.Presentation;

public class AppSettings
{
    public required BrokerOptions BrokerConfiguration { get; init; }
    public required MongoDbOptions MongoDbConfigurations { get; set; }
    //public required ElasticSearchConfiguration ElasticSearchConfiguration { get; init; }
}

//public class ElasticSearchConfiguration
//{
//    public required string Host { get; init; }
//    public required string UserName { get; init; }
//    public required string Password { get; init; }
//    public required string FingerPrint { get; init; }
//}

public sealed class BrokerOptions
{
    public const string SectionName = "BrokerConfiguration";

    public required string Host { get; init; }
    public required string UserName { get; init; }
    public required string Password { get; init; }
}

public sealed class MongoDbOptions
{
    public const string SectionName = "MongoDbConfigurations";

    public required string Host { get; set; }
    public required string DatabaseName { get; set; }
}