using Application.DTOs.Towar;
using Application.Interfaces.Services;
using AutoMapper;
using Core;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class TowarService : ITowarService
{
    private readonly IGenericRepository<Towar> _towarRepository;
    private readonly IMapper _mapper;

    public TowarService(IGenericRepository<Towar> towarRepository, IMapper mapper)
    {
        _towarRepository = towarRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<TowarDto>> GetAllAsync()
    {
        var towary = await _towarRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<TowarDto>>(towary);
    }

    public async Task<TowarDto> GetByIdAsync(int id)
    {
        var towar = await _towarRepository.GetByIdAsync(id);
        return _mapper.Map<TowarDto>(towar);
    }

    public async Task<TowarDto> AddAsync(TowarCreateDto towarCreateDto)
    {
        var towar = _mapper.Map<Towar>(towarCreateDto);
        towar = await _towarRepository.AddAsync(towar);
        return _mapper.Map<TowarDto>(towar);
    }

    public async Task UpdateAsync(TowarDto towarDto)
    {
        var towar = _mapper.Map<Towar>(towarDto);
        await _towarRepository.UpdateAsync(towar);
    }

    public async Task DeleteAsync(int id)
    {
        var towar = await _towarRepository.GetByIdAsync(id);
        await _towarRepository.DeleteAsync(towar);
    }
}
