using Core;

namespace Application.Interfaces.Services;

public interface IPozycjaTowaruService
{
    Task<IEnumerable<PozycjaTowaru>> GetAllAsync();
    Task<PozycjaTowaru> GetByIdAsync(int id);
    Task<PozycjaTowaru> AddAsync(PozycjaTowaru pozycjaTowaru);
    Task UpdateAsync(PozycjaTowaru pozycjaTowaru);
    Task DeleteAsync(int id);
}

