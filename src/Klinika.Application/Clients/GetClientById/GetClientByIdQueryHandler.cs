using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Clients.GetClientById;

public class GetClientByIdQueryHandler(IClientRepository ClientRepository) : IRequestHandler<GetClientByIdQuery, Client>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;

    public async Task<Client> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _ClientRepository.GetByIdAsync(request.Id) ?? throw new Exception("Client not found for the given id.");
    }
}

