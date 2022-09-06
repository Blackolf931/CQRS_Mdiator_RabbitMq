using BLL.Models;
using MediatR;

namespace BLL.Requests.Offices
{
    public record DeleteOfficeCommand(Office Office) : IRequest<Unit>;
}
