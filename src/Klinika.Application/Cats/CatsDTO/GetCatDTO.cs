using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Cats.CatsDTO;

public sealed record GetCatClientDTO(
    string UserName,
    string Name,
    string Surname
    );
public sealed record GetCatDTO(
    Guid Guid,
    string Name,
    int Age,
    string Color,
    List<GetCatClientDTO> Owners
    );
