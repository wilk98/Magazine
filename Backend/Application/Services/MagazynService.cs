using Application.DTOs.Magazyn;
using Application.Interfaces.Services;
using AutoMapper;
using Core;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class MagazynService : IMagazynService
{
    private readonly IGenericRepository<Magazyn> _magazynRepository;
    private readonly IMapper _mapper;

    public MagazynService(IGenericRepository<Magazyn> magazynRepository, IMapper mapper)
    {
        _magazynRepository = magazynRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<MagazynDto>> GetAllAsync()
    {
        var magazyny = await _magazynRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<MagazynDto>>(magazyny);
    }

    public async Task<MagazynDto> GetByIdAsync(int id)
    {
        var magazyn = await _magazynRepository.GetByIdAsync(id);
        return _mapper.Map<MagazynDto>(magazyn);
    }

    public async Task<MagazynDto> AddAsync(MagazynCreateDto magazynCreateDto)
    {
        var magazyn = _mapper.Map<Magazyn>(magazynCreateDto);
        magazyn = await _magazynRepository.AddAsync(magazyn);
        return _mapper.Map<MagazynDto>(magazyn);
    }

    public async Task UpdateAsync(MagazynDto magazynUpdateDto)
    {
        var magazyn = _mapper.Map<Magazyn>(magazynUpdateDto);
        await _magazynRepository.UpdateAsync(magazyn);
    }

    public async Task DeleteAsync(int id)
    {
        var magazyn = await _magazynRepository.GetByIdAsync(id);
        await _magazynRepository.DeleteAsync(magazyn);
    }
}
