using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Cats.GetCatById;

public class GetClientByIdQueryHandler(ICatRepository CatRepository) : IRequestHandler<GetClientByIdQuery, Cat>
{
    private readonly ICatRepository _CatRepository = CatRepository;

    public async Task<Cat> Handle(GetClientByIdQuery request, CancellationToken cancellationToken)
    {
        return await _CatRepository.GetByIdAsync(request.Id) ?? throw new Exception("Cat not found for the given id.");
    }
}

