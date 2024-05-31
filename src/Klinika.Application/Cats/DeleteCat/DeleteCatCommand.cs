using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.DeleteCat;

public class DeleteClientCommand(int id) : IRequest<Cat>
{
    public int Id { get; } = id;
}

