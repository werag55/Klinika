using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.UpdateAppoitment;

public class UpdateAppoitmentCommand(int id, Appoitment appoitment) : IRequest<Appoitment>
{
    public int Id { get; } = id;
    public Appoitment Appoitment { get; } = appoitment;
}
