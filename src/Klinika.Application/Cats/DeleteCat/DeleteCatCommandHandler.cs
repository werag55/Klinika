using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.DeleteCat;

public class DeleteCatCommandHandler : IRequestHandler<DeleteCatCommand, Cat>
{
    private readonly ICatRepository _CatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteCatCommandHandler(ICatRepository CatRepository, IUnitOfWork unitOfWork)
    {
        _CatRepository = CatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Cat> Handle(DeleteCatCommand request, CancellationToken cancellationToken)
    {
        var Cat = await _CatRepository.GetByIdAsync(request.Id);
        if (Cat != null)
        {
            _CatRepository.Remove(Cat);
            await _unitOfWork.SaveChangesAsync();
        }
        return Cat ?? throw new Exception("Cat not found for the given id."); ;
    }
}

