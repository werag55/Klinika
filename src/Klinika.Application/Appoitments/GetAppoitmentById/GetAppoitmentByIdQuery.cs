using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.GetAppoitmentById;

public class GetAppoitmentByIdQuery(int id) : IRequest<Appoitment>
{
    public int Id { get; } = id;
}
