using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.CreateCat;

public class CreateCatCommandHandler(ICatRepository CatRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateCatCommand, Cat>
{
    private readonly ICatRepository _CatRepository = CatRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Cat> Handle(CreateCatCommand request, CancellationToken cancellationToken)
    {
        _CatRepository.Add(request.Cat);
        await _unitOfWork.SaveChangesAsync();
        return request.Cat;
    }
}
