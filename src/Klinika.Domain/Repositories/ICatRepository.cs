using Klinika.Domain.Models;


namespace Klinika.Domain.Repositories;

public interface ICatRepository
{
    Task<List<Cat>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Cat?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

    void Add(Cat cat);
    void Update(Cat cat);
    void Remove(Cat cat);
}
