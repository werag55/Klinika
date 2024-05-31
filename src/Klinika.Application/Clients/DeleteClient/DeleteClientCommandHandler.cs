using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Clients.DeleteClient;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Client>
{
    private readonly IClientRepository _ClientRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClientCommandHandler(IClientRepository ClientRepository, IUnitOfWork unitOfWork)
    {
        _ClientRepository = ClientRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Client> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
    {
        var Client = await _ClientRepository.GetByIdAsync(request.Id);
        if (Client != null)
        {
            _ClientRepository.Remove(Client);
            await _unitOfWork.SaveChangesAsync();
        }
        return Client ?? throw new Exception("Client not found for the given id."); ;
    }
}

