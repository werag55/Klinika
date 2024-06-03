using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Infrastructure.Repositories;

internal sealed class CatRepository : ICatRepository
{
    private readonly AppDbContext _dbContext;

    public CatRepository(AppDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(Cat cat) =>
        _dbContext.Set<Cat>().Add(cat);

    public async Task<List<Cat>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Cat>().Include(client => client.Owners)
                .ToListAsync(cancellationToken);

    public async Task<Cat?> GetByGuidAsync(string guid, CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Cat>().Include(client => client.Owners)
                .FirstOrDefaultAsync(member => member.Guid.ToString() == guid, cancellationToken);

    public void Remove(Cat cat) =>
        _dbContext.Set<Cat>().Remove(cat);

    public void Update(Cat cat) =>
        _dbContext.Set<Cat>().Update(cat);
}
