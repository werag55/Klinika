using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Clients.CreateClient;

public class CreateClientCommand(Client Client) : IRequest<Client>
{
    public Client Client { get; } = Client;
}

