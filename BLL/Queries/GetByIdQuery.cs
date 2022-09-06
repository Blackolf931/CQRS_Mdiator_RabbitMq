using BLL.Models;
using MediatR;

namespace BLL.Queries
{
    public record GetByIdQuery(int Id): IRequest<Office>;
}
