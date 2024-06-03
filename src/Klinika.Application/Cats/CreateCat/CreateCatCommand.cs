using Klinika.Application.Cats.CatsDTO;
using MediatR;

namespace Klinika.Application.Cats.CreateCat;

public class CreateCatCommand(string userName, UpsertCatDTO Cat) : IRequest<GetCatDTO>
{
    public string UserName { get; } = userName;
    public UpsertCatDTO Cat { get; } = Cat;
}

