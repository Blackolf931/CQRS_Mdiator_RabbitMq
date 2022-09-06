using BLL.Models;

namespace BLL.Interfaces
{
    public interface INotificationService
    {
        Task EventOccured(IEnumerable<Office> offices, Office office, string evt);
    }
}
