using System.Collections.Generic;
using MediatR;
using Klinika.Domain.Models;

namespace Klinika.Application.Clients.GetClients;

public class GetClientsQuery(int page, int pageSize) : IRequest<IEnumerable<Client>>
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
}
