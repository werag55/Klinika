﻿using Klinika.Domain.Models;


namespace Klinika.Domain.Repositories;

public interface IAppoitmentRepository
{
    Task<List<Appoitment>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Appoitment?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Appoitment Appoitment);
    void Update(Appoitment Appoitment);
    void Remove(Appoitment Appoitment);
}