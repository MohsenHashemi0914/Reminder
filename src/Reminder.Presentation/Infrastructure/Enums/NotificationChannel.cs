namespace Reminder.Presentation.Infrastructure.Enums;

[Flags]
public enum NotificationChannel
{
    Sms = 1,
    Email,
    MsTeams,
    Telegram,
    Slack
}