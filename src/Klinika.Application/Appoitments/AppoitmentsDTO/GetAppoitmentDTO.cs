using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Appoitments.AppoitmentsDTO;

public sealed record GetAppoitmentCatDTO (
    string Name,
    int Age,
    string Color
    );

public sealed record GetAppoitmentClientDTO(
    string UserName,
    string Name,
    string Surname
    );

public sealed record GetAppoitmentDTO(
    Guid Guid,
    DateTime Date,
    GetAppoitmentCatDTO Cat,
    GetAppoitmentClientDTO Client
    );
