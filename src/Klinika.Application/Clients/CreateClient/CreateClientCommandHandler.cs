using AutoMapper;
using Klinika.Application.Clients.ClientsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.CreateClient;

public class CreateClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork, IMapper Mapper) 
    : IRequestHandler<CreateClientCommand, GetClientDTO>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _Mapper = Mapper;

    public async Task<GetClientDTO> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        Client client = _Mapper.Map<Client>(request.Client);

        _ClientRepository.Add(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _Mapper.Map<GetClientDTO>(request.Client);
    }
}
