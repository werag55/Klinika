using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Appoitments.GetAppoitmentById;

public class GetAppoitmentByIdQueryHandler(IAppoitmentRepository appoitmentRepository) : IRequestHandler<GetAppoitmentByIdQuery, Appoitment>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;

    public async Task<Appoitment> Handle(GetAppoitmentByIdQuery request, CancellationToken cancellationToken)
    {
        return await _appoitmentRepository.GetByIdAsync(request.Id) ?? throw new Exception("Appoitment not found for the given id.");
    }
}

