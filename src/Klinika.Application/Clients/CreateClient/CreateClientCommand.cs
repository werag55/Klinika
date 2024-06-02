using Klinika.Application.Clients.ClientsDTO;
using MediatR;

namespace Klinika.Application.Clients.CreateClient;

public class CreateClientCommand(UpsertClientDTO Client) : IRequest<UpsertClientDTO>
{
    public UpsertClientDTO Client { get; } = Client;
}

