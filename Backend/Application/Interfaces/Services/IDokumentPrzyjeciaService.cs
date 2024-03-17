using Application.DTOs.DokumentPrzyjecia;
using Core;

namespace Application.Interfaces.Services;

public interface IDokumentPrzyjeciaService
{
    Task<DokumentPrzyjeciaDto> AddAsync(DokumentPrzyjeciaCreateDto dokumentPrzyjecia);
    Task<IEnumerable<DokumentPrzyjeciaDto>> GetAllAsync();
    Task<DokumentPrzyjeciaDto> GetByIdAsync(int id);
    Task ZatwierdzDokumentPrzyjeciaAsync(int dokumentPrzyjeciaId);
    Task AnulujDokumentPrzyjeciaAsync(int dokumentPrzyjeciaId);
    Task UpdateAsync(DokumentPrzyjeciaUpdateDto dokumentUpdateDto);
}
