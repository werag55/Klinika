using AutoMapper;
using Klinika.Application.Clients.ClientsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.CreateClient;

public class CreateClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork, IMapper Mapper) 
    : IRequestHandler<CreateClientCommand, UpsertClientDTO>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _Mapper = Mapper;

    public async Task<UpsertClientDTO> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        Client client = _Mapper.Map<Client>(request.Client);

        _ClientRepository.Add(client);
        await _unitOfWork.SaveChangesAsync();
        return request.Client;
    }
}
