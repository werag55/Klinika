﻿using Klinika.Application.Appoitments.AppoitmentsDTO;
using Klinika.Domain.Models;
using MediatR;

namespace Klinika.Application.Appoitments.CreateAppoitment;

public class CreateAppoitmentCommand(string userName, UpsertAppoitmentDTO appoitment) : IRequest<GetAppoitmentDTO>
{
    public string UserName { get; } = userName;
    public UpsertAppoitmentDTO Appoitment { get; } = appoitment;
}

