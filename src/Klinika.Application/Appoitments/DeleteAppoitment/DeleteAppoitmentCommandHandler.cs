using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Appoitments.DeleteAppoitment;

public class DeleteAppoitmentCommandHandler : IRequestHandler<DeleteAppoitmentCommand, Appoitment>
{
    private readonly IAppoitmentRepository _appoitmentRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteAppoitmentCommandHandler(IAppoitmentRepository appoitmentRepository, IUnitOfWork unitOfWork)
    {
        _appoitmentRepository = appoitmentRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Appoitment> Handle(DeleteAppoitmentCommand request, CancellationToken cancellationToken)
    {
        var appoitment = await _appoitmentRepository.GetByGuidAsync(request.Guid, cancellationToken);
        if (appoitment != null)
        {
            _appoitmentRepository.Remove(appoitment);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        return appoitment ?? throw new Exception("Appoitment not found for the given Guid."); ;
    }
}

