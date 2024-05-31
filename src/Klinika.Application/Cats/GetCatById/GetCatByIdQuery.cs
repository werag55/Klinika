using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.GetCatById;

public class GetCatByIdQuery(int id) : IRequest<Cat>
{
    public int Id { get; } = id;
}
