using System.Collections.Generic;
using MediatR;
using Klinika.Domain.Models;

namespace Klinika.Application.Requests
{
    public class GetAppointmentsQuery : IRequest<IEnumerable<Appoitment>>
    {
        public int Page { get; }
        public int PageSize { get; }

        public GetAppointmentsQuery(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
