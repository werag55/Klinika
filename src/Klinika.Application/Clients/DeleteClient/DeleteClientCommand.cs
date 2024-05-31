using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Clients.DeleteClient;

public class DeleteClientCommand(int id) : IRequest<Client>
{
    public int Id { get; } = id;
}

