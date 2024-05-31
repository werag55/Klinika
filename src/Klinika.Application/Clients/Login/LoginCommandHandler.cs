using Klinika.Application.Abstractions;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using System.Security.Authentication;

namespace Klinika.Application.Clients.Login;

internal sealed class LoginCommandHandler(IClientRepository clientRepository, IJwtProvider jwtProvider) : IRequestHandler<LoginCommand, string>
{
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        Client? client = await _clientRepository.GetByUserNameAsync(request.UserName, cancellationToken);

        if (client == null)
            throw new InvalidCredentialException();

        string token = _jwtProvider.Generate(client);
        return token;
    }
}
