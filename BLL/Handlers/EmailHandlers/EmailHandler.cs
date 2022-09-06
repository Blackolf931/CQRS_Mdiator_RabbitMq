using BLL.Interfaces;
using BLL.Notification;
using MediatR;

namespace BLL.Handlers.EmailHandlers
{
    public class EmailHandler : INotificationHandler<OfficeAddedNotification>
    {
        private readonly INotificationService _notificationService;

        public EmailHandler(INotificationService notificatioNservice)
        {
            _notificationService = notificatioNservice;
        }

        public async Task Handle(OfficeAddedNotification notification, CancellationToken cancellationToken)
        {
            await _notificationService.EventOccured(notification.Offices, notification.Office, "Email sent");
            await Task.CompletedTask;
        }
    }
}
