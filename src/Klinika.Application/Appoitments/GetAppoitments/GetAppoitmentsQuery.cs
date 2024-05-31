using System.Collections.Generic;
using MediatR;
using Klinika.Domain.Models;

namespace Klinika.Application.Requests
{
    public class GetAppointmentsQuery(int page, int pageSize) : IRequest<IEnumerable<Appoitment>>
    {
        public int Page { get; } = page;
        public int PageSize { get; } = pageSize;
    }
}
