using Klinika.Domain.Models;


namespace Klinika.Domain.Repositories;

public interface IClientRepository
{
    Task<List<Client>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Client?> GetByGuidAsync(string guid, CancellationToken cancellationToken = default);

    Task<Client?> GetByUserNameAsync(string userName, CancellationToken cancellationToken = default);

    void Add(Client Client);
    void Update(Client Client);
    void Remove(Client Client);
}
