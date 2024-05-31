using MediatR;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Application.Cats.GetCats;

public class GetCatQueryHandler(ICatRepository catRepository) : IRequestHandler<GetClientsQuery, IEnumerable<Cat>>
{
    private readonly ICatRepository _catRepository = catRepository;

    public async Task<IEnumerable<Cat>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return await _catRepository.GetAllAsync();
    }
}

