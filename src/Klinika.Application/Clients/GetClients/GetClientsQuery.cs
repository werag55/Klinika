using System.Collections.Generic;
using MediatR;
using Klinika.Application.Clients.ClientsDTO;

namespace Klinika.Application.Clients.GetClients;

public class GetClientsQuery(int page, int pageSize) : IRequest<IEnumerable<GetClientDTO>>
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
}
