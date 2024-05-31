using MediatR;

namespace Klinika.Application.Clients.Login;

public class LoginCommand(string userName) : IRequest<string>
{
    public string UserName = userName;
}
