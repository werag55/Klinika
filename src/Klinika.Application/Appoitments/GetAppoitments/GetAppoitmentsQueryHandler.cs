using MediatR;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using AutoMapper;
using Klinika.Application.Appoitments.AppoitmentsDTO;

namespace Klinika.Application.Appoitments.GetAppoitments;

public class GetAppoitmentsQueryHandler(IAppoitmentRepository appoitmentRepository, IMapper Mapper) 
    : IRequestHandler<GetAppoitmentsQuery, IEnumerable<GetAppoitmentDTO>>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;
    private readonly IMapper _Mapper = Mapper;

    public async Task<IEnumerable<GetAppoitmentDTO>> Handle(GetAppoitmentsQuery request, CancellationToken cancellationToken)
    {
        return _Mapper.Map<List<GetAppoitmentDTO>>(await _appoitmentRepository.GetAllAsync(cancellationToken));
    }
}


