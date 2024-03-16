using Application.DTOs.Dostawca;
using Application.Interfaces.Services;
using AutoMapper;
using Core;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class DostawcaService : IDostawcaService
{
    private readonly IGenericRepository<Dostawca> _dostawcaRepository;
    private readonly IMapper _mapper;

    public DostawcaService(IGenericRepository<Dostawca> dostawcaRepository, IMapper mapper)
    {
        _dostawcaRepository = dostawcaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<DostawcaDto>> GetAllAsync()
    {
        var dostawcy = await _dostawcaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DostawcaDto>>(dostawcy);
    }

    public async Task<DostawcaDto> GetByIdAsync(int id)
    {
        var dostawca = await _dostawcaRepository.GetByIdAsync(id);
        return _mapper.Map<DostawcaDto>(dostawca);
    }

    public async Task<DostawcaDto> AddAsync(DostawcaCreateDto dostawcaCreateDto)
    {
        var dostawca = _mapper.Map<Dostawca>(dostawcaCreateDto);
        dostawca = await _dostawcaRepository.AddAsync(dostawca);
        return _mapper.Map<DostawcaDto>(dostawca);
    }

    public async Task UpdateAsync(DostawcaDto dostawcaDto)
    {
        var dostawca = _mapper.Map<Dostawca>(dostawcaDto);
        await _dostawcaRepository.UpdateAsync(dostawca);
    }

    public async Task DeleteAsync(int id)
    {
        var dostawca = await _dostawcaRepository.GetByIdAsync(id);
        await _dostawcaRepository.DeleteAsync(dostawca);
    }
}
