using Klinika.Application.Cats.CatsDTO;
using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Cats.UpdateCat;

public class UpdateCatCommand(string guid, UpsertCatDTO Cat) : IRequest<GetCatDTO>
{
    public string Guid { get; } = guid;
    public UpsertCatDTO Cat { get; } = Cat;
}
