using MediatR;
using Klinika.Application.Appoitments.AppoitmentsDTO;

namespace Klinika.Application.Appoitments.GetAppoitments;

public class GetAppoitmentsQuery(int page, int pageSize) : IRequest<IEnumerable<GetAppoitmentDTO>>
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
}

