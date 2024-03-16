using Application.DTOs.Magazyn;
using Core;

namespace Application.Interfaces.Services;

public interface IMagazynService
{
    Task<IEnumerable<MagazynDto>> GetAllAsync();
    Task<MagazynDto> GetByIdAsync(int id);
    Task<MagazynDto> AddAsync(MagazynCreateDto magazyn);
    Task UpdateAsync(MagazynDto magazyn);
    Task DeleteAsync(int id);
}