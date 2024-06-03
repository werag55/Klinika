using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Appoitments.CheckAppoitmentByDate;

public class CheckAppoitmentByIdQueryHandler(IAppoitmentRepository appoitmentRepository) 
    : IRequestHandler<CheckAppoitmentByDateQuery, bool>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;

    public async Task<bool> Handle(CheckAppoitmentByDateQuery request, CancellationToken cancellationToken)
    {
        Appoitment? appoitment = await _appoitmentRepository.GetByDateAsync(request.Date);
        return  appoitment != null; // returns true if there is an appoitment with a given date
    }
}

