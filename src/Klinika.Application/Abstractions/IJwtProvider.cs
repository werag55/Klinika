using Klinika.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Klinika.Application.Abstractions;

public interface IJwtProvider
{
    string Generate(Client client);
}
