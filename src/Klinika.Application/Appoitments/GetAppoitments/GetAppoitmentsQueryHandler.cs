using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Application.Appoitments.GetAppoitments;

public class GetAppoitmentsQueryHandler(IAppoitmentRepository appoitmentRepository) : IRequestHandler<GetAppoitmentsQuery, IEnumerable<Appoitment>>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;

    public async Task<IEnumerable<Appoitment>> Handle(GetAppoitmentsQuery request, CancellationToken cancellationToken)
    {
        return await _appoitmentRepository.GetAllAsync();
    }
}


