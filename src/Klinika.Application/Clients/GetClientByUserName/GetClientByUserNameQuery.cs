using Klinika.Application.Clients.ClientsDTO;
using MediatR;

namespace Klinika.Application.Clients.GetClientByUserName;

public class GetClientByUserNameQuery(string userName) : IRequest<GetClientDTO>
{
    public string UserName { get; } = userName;
}
