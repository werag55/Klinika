using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Clients.UpdateClient;

public class UpdateClientCommand(int id, Client Client) : IRequest<Client>
{
    public int Id { get; } = id;
    public Client Client { get; } = Client;
}
