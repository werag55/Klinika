using AutoMapper;
using Klinika.Application.Appoitments.AppoitmentsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Appoitments.CreateAppoitment;

public class CreateAppoitmentCommandHandler(IAppoitmentRepository appoitmentRepository, ICatRepository catRepository,
    IClientRepository clientRepository, IUnitOfWork unitOfWork, IMapper Mapper) 
    : IRequestHandler<CreateAppoitmentCommand, GetAppoitmentDTO>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;
    private readonly ICatRepository _catRepository = catRepository;
    private readonly IClientRepository _clientRepository = clientRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _Mapper = Mapper;

    public async Task<GetAppoitmentDTO> Handle(CreateAppoitmentCommand request, CancellationToken cancellationToken)
    {
        Appoitment appoitment = _Mapper.Map<Appoitment>(request.Appoitment);

        Cat cat = await _catRepository.GetByGuidAsync(request.Appoitment.CatGuid, cancellationToken)
            ?? throw new Exception("Cat not found for the given Guid.");
        appoitment.Cat = cat;
        appoitment.CatId = cat.Id;

        Client client = await _clientRepository.GetByGuidAsync(request.Appoitment.ClientGuid, cancellationToken)
            ?? throw new Exception("Client not found for the given Guid.");

        appoitment.Client = client;
        appoitment.ClientId = client.Id;


        _appoitmentRepository.Add(appoitment);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _Mapper.Map<GetAppoitmentDTO>(appoitment);
    }
}
