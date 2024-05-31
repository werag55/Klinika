﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Klinika.Domain.Models;
using Klinika.Domain.Repositories;

namespace Klinika.Application.Requests
{
    public class GetAppointmentsQueryHandler(IAppoitmentRepository appointmentRepository) : IRequestHandler<GetAppointmentsQuery, IEnumerable<Appoitment>>
    {
        private readonly IAppoitmentRepository _appointmentRepository = appointmentRepository;

        public async Task<IEnumerable<Appoitment>> Handle(GetAppointmentsQuery request, CancellationToken cancellationToken)
        {
            return await _appointmentRepository.GetAllAsync();
        }
    }
}

