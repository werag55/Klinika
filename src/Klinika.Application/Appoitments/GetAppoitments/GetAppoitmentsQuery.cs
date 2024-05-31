using System.Collections.Generic;
using MediatR;
using Klinika.Domain.Models;

namespace Klinika.Application.Appoitments.GetAppoitments;

public class GetAppoitmentsQuery(int page, int pageSize) : IRequest<IEnumerable<Appoitment>>
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
}

