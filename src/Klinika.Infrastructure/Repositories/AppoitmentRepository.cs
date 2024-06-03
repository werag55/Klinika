using Klinika.Domain.Models;
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
                .Set<Appoitment>().Include(client => client.Cat).Include(client => client.Client)
                .ToListAsync(cancellationToken);

    public async Task<Appoitment?> GetByDateAsync(DateTime date, CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Appoitment>().Include(client => client.Cat).Include(client => client.Client)
                .FirstOrDefaultAsync(member => member.Date.Date == date.Date && member.Date.Hour == date.Hour, cancellationToken);

    public async Task<Appoitment?> GetByGuidAsync(string guid, CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Appoitment>().Include(client => client.Cat).Include(client => client.Client)
                .FirstOrDefaultAsync(member => member.Guid.ToString() == guid, cancellationToken);

    public void Remove(Appoitment Appoitment) =>
        _dbContext.Set<Appoitment>().Remove(Appoitment);

    public void Update(Appoitment Appoitment) =>
        _dbContext.Set<Appoitment>().Update(Appoitment);
}