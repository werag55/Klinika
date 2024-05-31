using Klinika.Domain.Models;


namespace Klinika.Domain.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Client?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Client Client);
    void Update(Client Client);
    void Remove(Client Client);
}
