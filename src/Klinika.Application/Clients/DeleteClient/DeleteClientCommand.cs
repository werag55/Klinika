using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Clients.DeleteClient;

public class DeleteClientCommand(string UserName) : IRequest<Client>
{
    public string UserName { get; } = UserName;
}

