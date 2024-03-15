using Application.Interfaces.Services;
using Core;
using Infrastructure.Interfaces;

namespace Application.Services;

public class TowarService : ITowarService
{
    private readonly IGenericRepository<Towar> _towarRepository;

    public TowarService(IGenericRepository<Towar> towarRepository)
    {
        _towarRepository = towarRepository;
    }

    public async Task<IEnumerable<Towar>> GetAllAsync()
    {
        return await _towarRepository.GetAllAsync();
    }

    public async Task<Towar> GetByIdAsync(int id)
    {
        return await _towarRepository.GetByIdAsync(id);
    }

    public async Task<Towar> AddAsync(Towar towar)
    {
        return await _towarRepository.AddAsync(towar);
    }

    public async Task UpdateAsync(Towar towar)
    {
        await _towarRepository.UpdateAsync(towar);
    }

    public async Task DeleteAsync(int id)
    {
        var towar = await GetByIdAsync(id);
        await _towarRepository.DeleteAsync(towar);
    }
}
