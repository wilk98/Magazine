using Application.Interfaces.Services;
using Core;
using Infrastructure.Interfaces;

namespace Application.Services;

public class DostawcaService : IDostawcaService
{
    private readonly IGenericRepository<Dostawca> _dostawcaRepository;

    public DostawcaService(IGenericRepository<Dostawca> dostawcaRepository)
    {
        _dostawcaRepository = dostawcaRepository;
    }

    public async Task<IEnumerable<Dostawca>> GetAllAsync()
    {
        return await _dostawcaRepository.GetAllAsync();
    }

    public async Task<Dostawca> GetByIdAsync(int id)
    {
        return await _dostawcaRepository.GetByIdAsync(id);
    }

    public async Task<Dostawca> AddAsync(Dostawca dostawca)
    {
        return await _dostawcaRepository.AddAsync(dostawca);
    }

    public async Task UpdateAsync(Dostawca dostawca)
    {
        await _dostawcaRepository.UpdateAsync(dostawca);
    }

    public async Task DeleteAsync(int id)
    {
        var dostawca = await GetByIdAsync(id);
        await _dostawcaRepository.DeleteAsync(dostawca);
    }
}
