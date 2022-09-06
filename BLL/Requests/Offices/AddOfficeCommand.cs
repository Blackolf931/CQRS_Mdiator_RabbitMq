using BLL.Models;
using MediatR;

namespace BLL.Requests.Offices
{
    public record AddOfficeCommand(Office Office) : IRequest<Office>;
}
