using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.GetCatById;

public class GetClientByIdQuery(int id) : IRequest<Cat>
{
    public int Id { get; } = id;
}
