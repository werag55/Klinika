using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.DeleteAppoitment;

public class DeleteAppoitmentCommand(int id) : IRequest<Appoitment>
{
    public int Id { get; } = id;
}

