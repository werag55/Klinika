using AutoMapper;
using Klinika.Application.Clients.ClientsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Clients.GetClientByUserName;

public class GetClientByUserNameQueryHandler(IClientRepository ClientRepository, IMapper Mapper) : IRequestHandler<GetClientByUserNameQuery, GetClientDTO>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;
    private readonly IMapper _Mapper = Mapper;

    public async Task<GetClientDTO> Handle(GetClientByUserNameQuery request, CancellationToken cancellationToken)
    {
        return _Mapper.Map<GetClientDTO>(await _ClientRepository.GetByUserNameAsync(request.UserName))
            ?? throw new Exception("Client not found for the given User Name.");
    }
}

