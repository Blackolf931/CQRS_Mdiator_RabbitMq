using BLL.Models;
using MediatR;

namespace BLL.Notification
{
    public record OfficeAddedNotification(IEnumerable<Office> Offices, Office Office) : INotification;
}
