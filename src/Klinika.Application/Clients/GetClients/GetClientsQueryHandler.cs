using MediatR;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Application.Clients.GetClients;

public class GetClientQueryHandler(IClientRepository ClientRepository) : IRequestHandler<GetClientsQuery, IEnumerable<Client>>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;

    public async Task<IEnumerable<Client>> Handle(GetClientsQuery request, CancellationToken cancellationToken)
    {
        return await _ClientRepository.GetAllAsync();
    }
}

