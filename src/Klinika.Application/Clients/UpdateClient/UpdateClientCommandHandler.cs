using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.UpdateClient;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Client>
{
    private readonly IClientRepository _ClientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork)
    {
        _ClientRepository = ClientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Client> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        _ClientRepository.Update(request.Client);
        await _unitOfWork.SaveChangesAsync();
        return request.Client;
    }
}

