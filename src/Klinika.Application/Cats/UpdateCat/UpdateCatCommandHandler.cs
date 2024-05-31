using Klinika.Application.Cats.CreateCat;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.UpdateCat;

public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Cat>
{
    private readonly ICatRepository _CatRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UpdateClientCommandHandler(ICatRepository CatRepository, IUnitOfWork unitOfWork)
    {
        _CatRepository = CatRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Cat> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        _CatRepository.Update(request.Cat);
        await _unitOfWork.SaveChangesAsync();
        return request.Cat;
    }
}

