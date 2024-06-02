using AutoMapper;
using Klinika.Application.Clients.ClientsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, GetClientDTO>
{
    private readonly IClientRepository _ClientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _Mapper;

    public UpdateClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork, IMapper Mapper)
    {
        _ClientRepository = ClientRepository;
        _unitOfWork = unitOfWork;
        _Mapper = Mapper;
    }

    public async Task<GetClientDTO> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        Client? client = await _ClientRepository.GetByUserNameAsync(request.UserName, cancellationToken);

        if (client == null)
            throw new Exception("Client not found for the given User Name.");

        client.Name = request.Client.Name;
        client.Surname = request.Client.Surname;

        _ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _Mapper.Map<GetClientDTO>(request.Client);
    }
}

