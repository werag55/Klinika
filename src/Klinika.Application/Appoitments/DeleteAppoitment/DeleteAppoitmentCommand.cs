using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.DeleteAppoitment;

public class DeleteAppoitmentCommand(string guid) : IRequest<Appoitment>
{
    public string Guid { get; } = guid;
}

