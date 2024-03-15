using Application.Interfaces.Services;
using Core;
using Infrastructure.Interfaces;

namespace Application.Services;

public class DokumentPrzyjeciaService : IDokumentPrzyjeciaService
{
    private readonly IGenericRepository<DokumentPrzyjecia> _dokumentPrzyjeciaRepository;

    public DokumentPrzyjeciaService(IGenericRepository<DokumentPrzyjecia> dokumentPrzyjeciaRepository)
    {
        _dokumentPrzyjeciaRepository = dokumentPrzyjeciaRepository;
    }

    public async Task<IEnumerable<DokumentPrzyjecia>> GetAllAsync()
    {
        return await _dokumentPrzyjeciaRepository.GetAllAsync();
    }

    public async Task<DokumentPrzyjecia> GetByIdAsync(int id)
    {
        return await _dokumentPrzyjeciaRepository.GetByIdAsync(id);
    }

    public async Task<DokumentPrzyjecia> AddAsync(DokumentPrzyjecia dokumentPrzyjecia)
    {
        return await _dokumentPrzyjeciaRepository.AddAsync(dokumentPrzyjecia);
    }

    public async Task UpdateAsync(DokumentPrzyjecia dokumentPrzyjecia)
    {
        await _dokumentPrzyjeciaRepository.UpdateAsync(dokumentPrzyjecia);
    }

    public async Task DeleteAsync(int id)
    {
        var dokumentPrzyjecia = await GetByIdAsync(id);
        await _dokumentPrzyjeciaRepository.DeleteAsync(dokumentPrzyjecia);
    }
}
