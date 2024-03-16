using Application.DTOs.Etykieta;
using Application.Interfaces.Services;
using AutoMapper;
using Core;
using Infrastructure.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class EtykietaService : IEtykietaService
{
    private readonly IGenericRepository<Etykieta> _etykietaRepository;
    private readonly IMapper _mapper;

    public EtykietaService(IGenericRepository<Etykieta> etykietaRepository, IMapper mapper)
    {
        _etykietaRepository = etykietaRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EtykietaDto>> GetAllAsync()
    {
        var etykiety = await _etykietaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<EtykietaDto>>(etykiety);
    }

    public async Task<EtykietaDto> GetByIdAsync(int id)
    {
        var etykieta = await _etykietaRepository.GetByIdAsync(id);
        return _mapper.Map<EtykietaDto>(etykieta);
    }

    public async Task<EtykietaDto> AddAsync(EtykietaCreateDto etykietaCreateDto)
    {
        var etykieta = _mapper.Map<Etykieta>(etykietaCreateDto);
        etykieta = await _etykietaRepository.AddAsync(etykieta);
        return _mapper.Map<EtykietaDto>(etykieta);
    }

    public async Task UpdateAsync(EtykietaDto etykietaDto)
    {
        var etykieta = _mapper.Map<Etykieta>(etykietaDto);
        await _etykietaRepository.UpdateAsync(etykieta);
    }

    public async Task DeleteAsync(int id)
    {
        var etykieta = await _etykietaRepository.GetByIdAsync(id);
        await _etykietaRepository.DeleteAsync(etykieta);
    }
}
