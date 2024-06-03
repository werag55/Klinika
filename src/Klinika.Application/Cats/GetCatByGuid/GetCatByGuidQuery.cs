using Klinika.Application.Cats.CatsDTO;
using MediatR;

namespace Klinika.Application.Cats.GetCatByGuid;

public class GetCatByGuidQuery(string guid) : IRequest<GetCatDTO>
{
    public string Guid { get; } = guid;
}
