﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Clients.ClientsDTO;

public sealed record GetClientCatDTO (
    Guid Guid,
    string Name, 
    int Age,
    string Color
    );
public sealed record GetClientDTO(
    string UserName,
    string Name,
    string Surname
    );