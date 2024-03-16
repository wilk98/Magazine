using Application.DTOs.Towar;
using Core;

namespace Application.Interfaces.Services;

public interface ITowarService
{
    Task<IEnumerable<TowarDto>> GetAllAsync();
    Task<TowarDto> GetByIdAsync(int id);
    Task<TowarDto> AddAsync(TowarCreateDto towar);
    Task UpdateAsync(TowarDto towar);
    Task DeleteAsync(int id);
}
