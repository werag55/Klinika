using MediatR;
using Klinika.Domain.Repositories;
using Klinika.Application.Clients.ClientsDTO;
using AutoMapper;

namespace Klinika.Application.Clients.GetClients;

public class GetClientQueryHandler(IClientRepository ClientRepository, IMapper Mapper) : IRequestHandler<GetClientsQuery, IEnumerable<GetClientDTO>>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;
    private readonly IMapper _Mapper = Mapper;

    public async Task<IEnumerable<GetClientDTO>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return _Mapper.Map<List<GetClientDTO>>(await _ClientRepository.GetAllAsync());
    }
}

