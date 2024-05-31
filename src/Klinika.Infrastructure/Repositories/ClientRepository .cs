using Klinika.Domain.Models;
using Klinika.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Klinika.Infrastructure.Repositories;

internal sealed class ClientRepository : IClientRepository
{
    private readonly AppDbContext _dbContext;

    public ClientRepository(AppDbContext dbContext) =>
        _dbContext = dbContext;

    public void Add(Client Client) =>
        _dbContext.Set<Client>().Add(Client);

    public async Task<List<Client>> GetAllAsync(CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Client>()
                .ToListAsync(cancellationToken);

    public async Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        await _dbContext
                .Set<Client>().Include(client => client.Cats)
                .FirstOrDefaultAsync(member => member.Id == id, cancellationToken);

    public void Remove(Client Client) =>
        _dbContext.Set<Client>().Remove(Client);

    public void Update(Client Client) =>
        _dbContext.Set<Client>().Update(Client);
}
