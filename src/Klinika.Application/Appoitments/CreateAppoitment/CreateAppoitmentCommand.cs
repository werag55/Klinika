using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.CreateAppoitment;

public class CreateAppoitmentCommand(Appoitment appoitment) : IRequest<Appoitment>
{
    public Appoitment Appoitment { get; } = appoitment;
}

