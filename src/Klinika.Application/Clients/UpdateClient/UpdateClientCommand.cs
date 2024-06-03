using Klinika.Application.Clients.ClientsDTO;
using MediatR;

namespace Klinika.Application.Clients.UpdateClient;

public class UpdateClientCommand(string UserName, UpdateClientDTO Client) : IRequest<GetClientDTO>
{
    public string UserName { get; } = UserName;
    public UpdateClientDTO Client { get; } = Client;
}
