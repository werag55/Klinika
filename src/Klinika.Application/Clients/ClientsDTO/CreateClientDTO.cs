using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Clients.ClientsDTO;

public sealed record CreateClientDTO(
    string UserName,
    string Name,
    string Surname
    );

