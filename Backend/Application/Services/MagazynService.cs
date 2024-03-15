using Application.Interfaces.Services;
using Core;
using Infrastructure.Interfaces;

namespace Application.Services;

public class MagazynService : IMagazynService
{
    private readonly IGenericRepository<Magazyn> _magazynRepository;

    public MagazynService(IGenericRepository<Magazyn> magazynRepository)
    {
        _magazynRepository = magazynRepository;
    }

    public async Task<IEnumerable<Magazyn>> GetAllAsync()
    {
        return await _magazynRepository.GetAllAsync();
    }

    public async Task<Magazyn> GetByIdAsync(int id)
    {
        return await _magazynRepository.GetByIdAsync(id);
    }

    public async Task<Magazyn> AddAsync(Magazyn magazyn)
    {
        return await _magazynRepository.AddAsync(magazyn);
    }

    public async Task UpdateAsync(Magazyn magazyn)
    {
        await _magazynRepository.UpdateAsync(magazyn);
    }

    public async Task DeleteAsync(int id)
    {
        var magazyn = await GetByIdAsync(id);
        await _magazynRepository.DeleteAsync(magazyn);
    }
}
