using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.UpdateCat;

public class UpdateCatCommand(int id, Cat Cat) : IRequest<Cat>
{
    public int Id { get; } = id;
    public Cat Cat { get; } = Cat;
}
