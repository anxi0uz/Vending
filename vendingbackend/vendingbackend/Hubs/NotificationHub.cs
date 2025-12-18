using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace vendingbackend.Hubs
{
    [Authorize]
    public class NotificationHub : Hub
    {
    }
}
