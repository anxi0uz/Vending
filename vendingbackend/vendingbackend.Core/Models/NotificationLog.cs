namespace vendingbackend.Core.Models;

public class NotificationLog
{
    public int Id { get; set; }
    public NotificationType Type { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
}

public enum NotificationType
{
    Success,
    Warning,
    Error,
    Information
}