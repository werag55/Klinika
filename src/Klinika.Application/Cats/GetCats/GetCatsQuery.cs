using MediatR;
using Klinika.Application.Cats.CatsDTO;

namespace Klinika.Application.Cats.GetCats;

public class GetCatsQuery(int page, int pageSize) : IRequest<IEnumerable<GetCatDTO>>
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
}
