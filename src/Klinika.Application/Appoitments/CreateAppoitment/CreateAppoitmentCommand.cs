using Klinika.Application.Appoitments.AppoitmentsDTO;
using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.CreateAppoitment;

public class CreateAppoitmentCommand(UpsertAppoitmentDTO appoitment) : IRequest<GetAppoitmentDTO>
{
    public UpsertAppoitmentDTO Appoitment { get; } = appoitment;
}

