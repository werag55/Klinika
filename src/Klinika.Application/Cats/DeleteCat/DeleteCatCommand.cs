using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.DeleteCat;

public class DeleteCatCommand(string guid) : IRequest<Cat>
{
    public string Guid { get; } = guid;
}

