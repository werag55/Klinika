using Klinika.Domain.Models;


namespace Klinika.Domain.Repositories;

public interface IAppoitmentRepository
{
    Task<List<Appoitment>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Appoitment?> GetByGuidAsync(string guid, CancellationToken cancellationToken = default);

    Task<Appoitment?> GetByDateAsync (DateTime date, CancellationToken cancellationToken = default);

    void Add(Appoitment Appoitment);
    void Update(Appoitment Appoitment);
    void Remove(Appoitment Appoitment);
}
