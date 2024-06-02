using MediatR;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Application.Cats.GetCats;

public class GetCatQueryHandler(ICatRepository catRepository) : IRequestHandler<GetCatsQuery, IEnumerable<Cat>>
{
    private readonly ICatRepository _catRepository = catRepository;

    public async Task<IEnumerable<Cat>> Handle(GetCatsQuery request, CancellationToken cancellationToken)
    {
        return await _catRepository.GetAllAsync();
    }
}

