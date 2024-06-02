using AutoMapper;
using Klinika.Application.Cats.CatsDTO;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;

namespace Klinika.Application.Cats.UpdateCat;

public class UpdateCatCommandHandler : IRequestHandler<UpdateCatCommand, GetCatDTO>
{
    private readonly ICatRepository _CatRepository;
    private readonly IClientRepository _ClientRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _Mapper;

    public UpdateCatCommandHandler(ICatRepository CatRepository, IClientRepository ClientRepository, IUnitOfWork unitOfWork, IMapper Mapper)
    {
        _CatRepository = CatRepository;
        _ClientRepository = ClientRepository;
        _unitOfWork = unitOfWork;
        _Mapper = Mapper;
    }

    public async Task<GetCatDTO> Handle(UpdateCatCommand request, CancellationToken cancellationToken)
    {
        Cat? cat = await _CatRepository.GetByGuidAsync(request.Guid, cancellationToken);

        if (cat == null)
            throw new Exception("Cat not found for the given Guid.");

        cat.Name = request.Cat.Name;
        cat.Age = request.Cat.Age;
        cat.Color = request.Cat.Color;
        cat.Owners = [];

        if (request.Cat.OwnersUserNames != null)
            foreach (var username in request.Cat.OwnersUserNames)
            {
                cat.Owners.Add(await _ClientRepository.GetByUserNameAsync(username, cancellationToken)
                    ?? throw new Exception("Clien not found for the given User Name."));
            }


        _CatRepository.Update(cat);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return _Mapper.Map<GetCatDTO>(request.Cat);
    }
}

