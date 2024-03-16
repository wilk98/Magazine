using Application.DTOs.Dostawca;
using Core;

namespace Application.Interfaces.Services;

public interface IDostawcaService
{
    Task<IEnumerable<DostawcaDto>> GetAllAsync();
    Task<DostawcaDto> GetByIdAsync(int id);
    Task<DostawcaDto> AddAsync(DostawcaCreateDto dostawca);
    Task UpdateAsync(DostawcaDto dostawca);
    Task DeleteAsync(int id);
}

