using Application.DTOs.Etykieta;
using Core;

namespace Application.Interfaces.Services;

public interface IEtykietaService
{
    Task<IEnumerable<EtykietaDto>> GetAllAsync();
    Task<EtykietaDto> GetByIdAsync(int id);
    Task<EtykietaDto> AddAsync(EtykietaCreateDto etykieta);
    Task UpdateAsync(EtykietaDto etykieta);
    Task DeleteAsync(int id);
}