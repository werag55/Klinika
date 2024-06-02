using Klinika.Application.Clients.ClientsDTO;
using MediatR;

namespace Klinika.Application.Clients.UpdateClient;

public class UpdateClientCommand(string UserName, UpsertClientDTO Client) : IRequest<UpsertClientDTO>
{
    public string UserName { get; } = UserName;
    public UpsertClientDTO Client { get; } = Client;
}
