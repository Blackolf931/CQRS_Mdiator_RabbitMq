using BLL.Interfaces;
using BLL.Models;

namespace BLL.services
{
    public class NotificationService : INotificationService
    {
        public async Task EventOccured(IEnumerable<Office> offices, Office office, string evt)
        {
            offices.FirstOrDefault(o => o.Id == office.Id).Name = $"{office.Name} evt:{evt}";
            await Task.CompletedTask;
        }
    }
}
