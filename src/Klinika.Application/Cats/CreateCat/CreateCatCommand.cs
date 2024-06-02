using Klinika.Application.Cats.CatsDTO;
using MediatR;

namespace Klinika.Application.Cats.CreateCat;

public class CreateCatCommand(UpsertCatDTO Cat) : IRequest<GetCatDTO>
{
    public UpsertCatDTO Cat { get; } = Cat;
}

