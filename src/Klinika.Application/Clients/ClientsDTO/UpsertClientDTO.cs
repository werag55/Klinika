using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Clients.ClientsDTO;

public sealed record UpdateClientDTO(
    string Name,
    string Surname
    );
