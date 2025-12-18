using Microsoft.AspNetCore.SignalR;
using vendingbackend.Core.Abstractions;
using vendingbackend.Core.DTOs;
using vendingbackend.Core.Models;
using vendingbackend.Infrastructure.DataAccess;

namespace vendingbackend.Hubs;

public class NotificationSender : INotificationSender
{
    private readonly IHubContext<NotificationHub> _notificationHub;
    private readonly AppDbContext _dbContext;

    public NotificationSender(IHubContext<NotificationHub> notificationHub, AppDbContext dbContext)
    {
        _notificationHub = notificationHub;
        _dbContext = dbContext;
    }
    
    public async Task SendNotificationAsync(NotificationDto notification)
    {
        var notificationLog = new NotificationLog()
        {
            Date = notification.Date,
            Message = notification.Message,
            Type = (NotificationType)notification.Type
        };
        await _dbContext.NotificationLogs.AddAsync(notificationLog);
        await _dbContext.SaveChangesAsync();
        await _notificationHub.Clients.All.SendAsync("TaNotification", notificationLog);
    }
}