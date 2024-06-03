using AutoMapper;
using Klinika.Application.Appoitments.AppoitmentsDTO;
using Klinika.Application.Appoitments.CreateAppoitment;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Appoitments.UpdateAppoitment;

public class UpdateAppoitmentCommandHandler : IRequestHandler<UpdateAppoitmentCommand, GetAppoitmentDTO>
{
    private readonly IAppoitmentRepository _appoitmentRepository;
    private readonly ICatRepository _catRepository;
    private readonly IClientRepository _clientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _Mapper;

    public UpdateAppoitmentCommandHandler(IAppoitmentRepository appoitmentRepository, ICatRepository catRepository,
        IClientRepository clientRepository, IUnitOfWork unitOfWork, IMapper Mapper)
    {
        _appoitmentRepository = appoitmentRepository;
        _catRepository = catRepository;
        _clientRepository = clientRepository;
        _unitOfWork = unitOfWork;
        _Mapper = Mapper;
    }

    public async Task<GetAppoitmentDTO> Handle(UpdateAppoitmentCommand request, CancellationToken cancellationToken)
    {
        Appoitment appoitment = await _appoitmentRepository.GetByGuidAsync(request.Guid, cancellationToken)
            ?? throw new Exception("Appoitment not found for the given Guid.");

        appoitment.Date = request.Appoitment.Date;

        if (appoitment.Cat.Guid.ToString() != request.Appoitment.CatGuid)
        {
            Cat cat = await _catRepository.GetByGuidAsync(request.Appoitment.CatGuid, cancellationToken)
                ?? throw new Exception("Cat not found for the given Guid.");
            appoitment.Cat = cat;
            appoitment.CatId = cat.Id;
        }

        _appoitmentRepository.Update(appoitment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _Mapper.Map<GetAppoitmentDTO>(appoitment);
    }
}

