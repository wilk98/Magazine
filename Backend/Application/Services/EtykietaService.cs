using Application.Interfaces.Services;
using Core;
using Infrastructure.Interfaces;

namespace Application.Services;

public class EtykietaService : IEtykietaService
{
    private readonly IGenericRepository<Etykieta> _etykietaRepository;

    public EtykietaService(IGenericRepository<Etykieta> etykietaRepository)
    {
        _etykietaRepository = etykietaRepository;
    }

    public async Task<IEnumerable<Etykieta>> GetAllAsync()
    {
        return await _etykietaRepository.GetAllAsync();
    }

    public async Task<Etykieta> GetByIdAsync(int id)
    {
        return await _etykietaRepository.GetByIdAsync(id);
    }

    public async Task<Etykieta> AddAsync(Etykieta etykieta)
    {
        return await _etykietaRepository.AddAsync(etykieta);
    }

    public async Task UpdateAsync(Etykieta etykieta)
    {
        await _etykietaRepository.UpdateAsync(etykieta);
    }

    public async Task DeleteAsync(int id)
    {
        var etykieta = await GetByIdAsync(id);
        await _etykietaRepository.DeleteAsync(etykieta);
    }
}
