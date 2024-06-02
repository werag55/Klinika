using Klinika.Application.Cats.CreateCat;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.UpdateCat;

public class UpdateCatCommandHandler : IRequestHandler<UpdateCatCommand, Cat>
{
    private readonly ICatRepository _CatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateCatCommandHandler(ICatRepository CatRepository, IUnitOfWork unitOfWork)
    {
        _CatRepository = CatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Cat> Handle(UpdateCatCommand request, CancellationToken cancellationToken)
    {
        _CatRepository.Update(request.Cat);
        await _unitOfWork.SaveChangesAsync();
        return request.Cat;
    }
}

