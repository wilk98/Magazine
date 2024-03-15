using Core;

namespace Application.Interfaces.Services;

public interface IMagazynService
{
    Task<IEnumerable<Magazyn>> GetAllAsync();
    Task<Magazyn> GetByIdAsync(int id);
    Task<Magazyn> AddAsync(Magazyn magazyn);
    Task UpdateAsync(Magazyn magazyn);
    Task DeleteAsync(int id);
}