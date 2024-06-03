using AutoMapper;
using Klinika.Application.Cats.CatsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.CreateCat;

public class CreateCatCommandHandler(ICatRepository CatRepository, IClientRepository ClientRepository, IUnitOfWork unitOfWork, IMapper Mapper) 
    : IRequestHandler<CreateCatCommand, GetCatDTO>
{
    private readonly ICatRepository _CatRepository = CatRepository;
    private readonly IClientRepository _ClientRepository = ClientRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IMapper _Mapper = Mapper;

    public async Task<GetCatDTO> Handle(CreateCatCommand request, CancellationToken cancellationToken)
    {
        Cat cat = _Mapper.Map<Cat>(request.Cat);
        cat.Owners = [];

        List<string>? OwnersUserNames = request.Cat.OwnersUserNames;
        OwnersUserNames ??= new List<string> { request.UserName };

        foreach (var username in OwnersUserNames)
        {
            cat.Owners.Add(await _ClientRepository.GetByUserNameAsync(username, cancellationToken)
                ?? throw new Exception("Clien not found for the given User Name."));
        }

        _CatRepository.Add(cat);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _Mapper.Map<GetCatDTO>(cat);
    }
}
