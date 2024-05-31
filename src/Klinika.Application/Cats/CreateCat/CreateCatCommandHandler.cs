using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.CreateCat;

public class CreateClientCommandHandler(ICatRepository CatRepository, IUnitOfWork unitOfWork) 
    : IRequestHandler<CreateClientCommand, Cat>
{
    private readonly ICatRepository _CatRepository = CatRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<Cat> Handle(CreateClientCommand request, CancellationToken cancellationToken)
    {
        _CatRepository.Add(request.Cat);
        await _unitOfWork.SaveChangesAsync();
        return request.Cat;
    }
}
