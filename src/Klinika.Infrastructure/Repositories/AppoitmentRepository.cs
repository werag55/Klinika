﻿using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Infrastructure.Repositories;

internal sealed class AppoitmentRepository : IAppoitmentRepository
{
    private readonly AppDbContext _dbContext;

    public AppoitmentRepository(AppDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(Appoitment Appoitment) =>
        _dbContext.Set<Appoitment>().Add(Appoitment);

    public async Task<List<Appoitment>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Appoitment>()
                .ToListAsync(cancellationToken);

    public async Task<Appoitment?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Appoitment>()
                .FirstOrDefaultAsync(member => member.Id == id, cancellationToken);

    public void Remove(Appoitment Appoitment) =>
        _dbContext.Set<Appoitment>().Remove(Appoitment);

    public void Update(Appoitment Appoitment) =>
        _dbContext.Set<Appoitment>().Update(Appoitment);
}