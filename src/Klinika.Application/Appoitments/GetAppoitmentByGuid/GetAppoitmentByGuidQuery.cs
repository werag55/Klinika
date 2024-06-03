using Klinika.Application.Appoitments.AppoitmentsDTO;
using MediatR;

namespace Klinika.Application.Appoitments.GetAppoitmentByGuid;

public class GetAppoitmentByGuidQuery(string guid) : IRequest<GetAppoitmentDTO>
{
    public string Guid { get; } = guid;
}
