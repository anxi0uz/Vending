using vendingbackend.Core.DTOs;

namespace vendingbackend.Core.Abstractions;

public interface INotificationSender
{
    Task SendNotificationAsync(NotificationDto notification);
}