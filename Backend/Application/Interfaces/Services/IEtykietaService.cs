using Core;

namespace Application.Interfaces.Services;

public interface IEtykietaService
{
    Task<IEnumerable<Etykieta>> GetAllAsync();
    Task<Etykieta> GetByIdAsync(int id);
    Task<Etykieta> AddAsync(Etykieta etykieta);
    Task UpdateAsync(Etykieta etykieta);
    Task DeleteAsync(int id);
}