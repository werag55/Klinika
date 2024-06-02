using Klinika.Application.Clients.ClientsDTO;
using MediatR;

namespace Klinika.Application.Clients.CreateClient;

public class CreateClientCommand(CreateClientDTO Client) : IRequest<GetClientDTO>
{
    public CreateClientDTO Client { get; } = Client;
}

