using BLL.Models;
using MediatR;

namespace BLL.Requests.Offices
{
    public record UpdateOfficeCommand(Office Office) : IRequest<Office>;
}
