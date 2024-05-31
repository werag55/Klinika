using Klinika.Application.Appoitments.CreateAppoitment;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Appoitments.UpdateAppoitment;

public class UpdateAppoitmentCommandHandler : IRequestHandler<UpdateAppoitmentCommand, Appoitment>
{
    private readonly IAppoitmentRepository _appoitmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateAppoitmentCommandHandler(IAppoitmentRepository appoitmentRepository, IUnitOfWork unitOfWork)
    {
        _appoitmentRepository = appoitmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Appoitment> Handle(UpdateAppoitmentCommand request, CancellationToken cancellationToken)
    {
        _appoitmentRepository.Update(request.Appoitment);
        await _unitOfWork.SaveChangesAsync();
        return request.Appoitment;
    }
}

