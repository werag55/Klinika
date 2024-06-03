using Klinika.Application.Appoitments.AppoitmentsDTO;
using MediatR;

namespace Klinika.Application.Appoitments.UpdateAppoitment;

public class UpdateAppoitmentCommand(string guid, UpsertAppoitmentDTO appoitment) : IRequest<GetAppoitmentDTO>
{
    public string Guid { get; } = guid;
    public UpsertAppoitmentDTO Appoitment { get; } = appoitment;
}
