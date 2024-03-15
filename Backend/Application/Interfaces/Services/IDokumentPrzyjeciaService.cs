using Core;

namespace Application.Interfaces.Services;

public interface IDokumentPrzyjeciaService
{
    Task<IEnumerable<DokumentPrzyjecia>> GetAllAsync();
    Task<DokumentPrzyjecia> GetByIdAsync(int id);
    Task<DokumentPrzyjecia> AddAsync(DokumentPrzyjecia dokumentPrzyjecia);
    Task UpdateAsync(DokumentPrzyjecia dokumentPrzyjecia);
    Task DeleteAsync(int id);
}
