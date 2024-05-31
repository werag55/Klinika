using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Appoitments.CreateAppoitment;

public class CreateAppoitmentCommandHandler(IAppoitmentRepository appoitmentRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateAppoitmentCommand, Appoitment>
{
    private readonly IAppoitmentRepository _appoitmentRepository = appoitmentRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Appoitment> Handle(CreateAppoitmentCommand request, CancellationToken cancellationToken)
    {
        _appoitmentRepository.Add(request.Appoitment);
        await _unitOfWork.SaveChangesAsync();
        return request.Appoitment;
    }
}
