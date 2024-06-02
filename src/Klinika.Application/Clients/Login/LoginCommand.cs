using Klinika.Application.Clients.ClientsDTO;
using MediatR;

namespace Klinika.Application.Clients.Login;

public class LoginCommand(LoginClientDTO login) : IRequest<string>
{
    public LoginClientDTO Login = login;
}
