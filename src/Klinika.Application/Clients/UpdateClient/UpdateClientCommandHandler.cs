using Klinika.Application.Clients.ClientsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, UpsertClientDTO>
{
    private readonly IClientRepository _ClientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork)
    {
        _ClientRepository = ClientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<UpsertClientDTO> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        Client? client = await _ClientRepository.GetByUserNameAsync(request.UserName);

        if (client == null)
            throw new Exception("Client not found for the given User Name.");

        client.Name = request.Client.Name;
        client.Surname = request.Client.Surname;

        _ClientRepository.Update(client);
        await _unitOfWork.SaveChangesAsync();
        return request.Client;
    }
}

