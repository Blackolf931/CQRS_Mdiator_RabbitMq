using BLL.Models;
using MediatR;

namespace BLL.Queries
{
    public record GetAllOfficeQuery() : IRequest<IEnumerable<Office>>
    {
    }
}