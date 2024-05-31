using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.CreateClient;

public class CreateClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateClientCommand, Client>
{
    private readonly IClientRepository _ClientRepository = ClientRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Client> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        _ClientRepository.Add(request.Client);
        await _unitOfWork.SaveChangesAsync();
        return request.Client;
    }
}
