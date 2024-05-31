using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Clients.GetClientById;

public class GetClientByIdQuery(int id) : IRequest<Client>
{
    public int Id { get; } = id;
}
