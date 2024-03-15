using Core;

namespace Application.Interfaces.Services;

public interface IDostawcaService
{
    Task<IEnumerable<Dostawca>> GetAllAsync();
    Task<Dostawca> GetByIdAsync(int id);
    Task<Dostawca> AddAsync(Dostawca dostawca);
    Task UpdateAsync(Dostawca dostawca);
    Task DeleteAsync(int id);
}

