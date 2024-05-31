using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.CheckAppoitmentByDate;

public class CheckAppoitmentByDateQuery(DateTime date) : IRequest<bool>
{
    public DateTime Date { get; } = date;
}
