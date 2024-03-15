using Application.Interfaces.Services;
using Core;
using Infrastructure.Interfaces;

namespace Application.Services;

public class PozycjaTowaruService : IPozycjaTowaruService
{
    private readonly IGenericRepository<PozycjaTowaru> _pozycjaTowaruRepository;

    public PozycjaTowaruService(IGenericRepository<PozycjaTowaru> pozycjaTowaruRepository)
    {
        _pozycjaTowaruRepository = pozycjaTowaruRepository;
    }

    public async Task<IEnumerable<PozycjaTowaru>> GetAllAsync()
    {
        return await _pozycjaTowaruRepository.GetAllAsync();
    }

    public async Task<PozycjaTowaru> GetByIdAsync(int id)
    {
        return await _pozycjaTowaruRepository.GetByIdAsync(id);
    }

    public async Task<PozycjaTowaru> AddAsync(PozycjaTowaru pozycjaTowaru)
    {
        return await _pozycjaTowaruRepository.AddAsync(pozycjaTowaru);
    }

    public async Task UpdateAsync(PozycjaTowaru pozycjaTowaru)
    {
        await _pozycjaTowaruRepository.UpdateAsync(pozycjaTowaru);
    }

    public async Task DeleteAsync(int id)
    {
        var pozycjaTowaru = await GetByIdAsync(id);
        await _pozycjaTowaruRepository.DeleteAsync(pozycjaTowaru);
    }
}
