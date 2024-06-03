using AutoMapper;
using Klinika.Application.Appoitments.AppoitmentsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;


namespace Klinika.Application.Appoitments.GetAppoitmentByGuid;

public class GetAppoitmentByGuidQueryHandler(IAppoitmentRepository appoitmentRepository, IMapper Mapper) 
    : IRequestHandler<GetAppoitmentByGuidQuery, GetAppoitmentDTO>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;
    private readonly IMapper _Mapper = Mapper;

    public async Task<GetAppoitmentDTO> Handle(GetAppoitmentByGuidQuery request, CancellationToken cancellationToken)
    {
        return _Mapper.Map<GetAppoitmentDTO>(await _appoitmentRepository.GetByGuidAsync(request.Guid, cancellationToken))
            ?? throw new Exception("Appoitment not found for the given Guid.");
    }
}

