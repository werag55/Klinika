using AutoMapper;
using Klinika.Application.Cats.CatsDTO;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.GetCatByGuid;

public class GetCatByGuidQueryHandler(ICatRepository CatRepository, IMapper Mapper) 
    : IRequestHandler<GetCatByGuidQuery, GetCatDTO>
{
    private readonly ICatRepository _CatRepository = CatRepository;
    private readonly IMapper _Mapper = Mapper;

    public async Task<GetCatDTO> Handle(GetCatByGuidQuery request, CancellationToken cancellationToken)
    {
        return _Mapper.Map<GetCatDTO>(await _CatRepository.GetByGuidAsync(request.Guid, cancellationToken))
            ?? throw new Exception("Cat not found for the given id.");
    }
}

