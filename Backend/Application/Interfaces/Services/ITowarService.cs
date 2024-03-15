using Core;

namespace Application.Interfaces.Services;

public interface ITowarService
{
    Task<IEnumerable<Towar>> GetAllAsync();
    Task<Towar> GetByIdAsync(int id);
    Task<Towar> AddAsync(Towar towar);
    Task UpdateAsync(Towar towar);
    Task DeleteAsync(int id);
}
