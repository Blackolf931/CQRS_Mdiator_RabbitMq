using BLL.Interfaces;
using BLL.Notification;
using MediatR;

namespace BLL.Handlers.EmailHandlers
{
    public class CacheInvalidationHandler : INotificationHandler<OfficeAddedNotification>
    {
        private readonly INotificationService _notificationService;

        public CacheInvalidationHandler(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public async Task Handle(OfficeAddedNotification notification, CancellationToken cancellationToken)
        {
            await _notificationService.EventOccured(notification.Offices, notification.Office, "Cache Invalidate");
            await Task.CompletedTask;
        }
    }
}
