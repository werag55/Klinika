using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Appoitments.AppoitmentsDTO
{
    public sealed record UpsertAppoitmentDTO(
        DateTime Date,
        string CatGuid
        );
}
