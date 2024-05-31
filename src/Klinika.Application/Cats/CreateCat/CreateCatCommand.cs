using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.CreateCat;

public class CreateClientCommand(Cat Cat) : IRequest<Cat>
{
    public Cat Cat { get; } = Cat;
}

