using MediatR;
using Klinika.Domain.Repositories;
using Klinika.Application.Cats.CatsDTO;
using AutoMapper;

namespace Klinika.Application.Cats.GetCats;

public class GetCatQueryHandler(ICatRepository catRepository, IMapper Mapper) 
    : IRequestHandler<GetCatsQuery, IEnumerable<GetCatDTO>>
{
    private readonly ICatRepository _catRepository = catRepository;
    private readonly IMapper _Mapper = Mapper;
    public async Task<IEnumerable<GetCatDTO>> Handle(GetCatsQuery request, CancellationToken cancellationToken)
    {
        return _Mapper.Map<List<GetCatDTO>>( await _catRepository.GetAllAsync(cancellationToken));
    }
}

