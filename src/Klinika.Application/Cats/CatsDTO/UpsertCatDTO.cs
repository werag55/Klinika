using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Cats.CatsDTO;

public sealed record UpsertCatDTO(
    Guid Guid,
    string Name,
    string Age,
    string Color,
    List<string>? OwnersUserNames
    );
