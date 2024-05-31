﻿using System.Collections.Generic;
using MediatR;
using Klinika.Domain.Models;

namespace Klinika.Application.Cats.GetCats;

public class GetClientsQuery(int page, int pageSize) : IRequest<IEnumerable<Cat>>
{
    public int Page { get; } = page;
    public int PageSize { get; } = pageSize;
}
