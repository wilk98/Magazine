using Core;
using Infrastructure.Interfaces;

namespace Application.Interfaces.Repositories;

public interface IDokumentPrzyjeciaRepository
{
    Task<IEnumerable<DokumentPrzyjecia>> GetAllAsync();
    Task<DokumentPrzyjecia> GetByIdAsync(int id);
    Task<DokumentPrzyjecia> AddAsync(DokumentPrzyjecia dokumentPrzyjecia, List<int> etykietyIds = null);

}
