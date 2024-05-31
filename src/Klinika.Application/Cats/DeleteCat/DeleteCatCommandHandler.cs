using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.DeleteCat;

public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, Cat>
{
    private readonly ICatRepository _CatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteClientCommandHandler(ICatRepository CatRepository, IUnitOfWork unitOfWork)
    {
        _CatRepository = CatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Cat> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
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

