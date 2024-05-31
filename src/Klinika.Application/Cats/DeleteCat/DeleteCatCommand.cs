using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.DeleteCat;

public class DeleteCatCommand(int id) : IRequest<Cat>
{
    public int Id { get; } = id;
}

