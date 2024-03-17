using Application.DTOs.DokumentPrzyjecia;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AutoMapper;
using Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Services;

public class DokumentPrzyjeciaService : IDokumentPrzyjeciaService
{
    private readonly IDokumentPrzyjeciaRepository _dokumentPrzyjeciaRepository;
    private readonly IMapper _mapper;

    public DokumentPrzyjeciaService(IDokumentPrzyjeciaRepository dokumentPrzyjeciaRepository, IMapper mapper)
    {
        _dokumentPrzyjeciaRepository = dokumentPrzyjeciaRepository;
        _mapper = mapper;
    }

    public async Task<DokumentPrzyjeciaDto> AddAsync(DokumentPrzyjeciaCreateDto dokumentCreateDto)
    {
        var dokumentPrzyjecia = _mapper.Map<DokumentPrzyjecia>(dokumentCreateDto);
        dokumentPrzyjecia = await _dokumentPrzyjeciaRepository.AddAsync(dokumentPrzyjecia, (List<int>)dokumentCreateDto.EtykietyIds);
        return _mapper.Map<DokumentPrzyjeciaDto>(dokumentPrzyjecia);
    }

    public async Task<IEnumerable<DokumentPrzyjeciaDto>> GetAllAsync()
    {
        var dokumenty = await _dokumentPrzyjeciaRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DokumentPrzyjeciaDto>>(dokumenty);
    }

    public async Task<DokumentPrzyjeciaDto> GetByIdAsync(int id)
    {
        var dokument = await _dokumentPrzyjeciaRepository.GetByIdAsync(id);
        return _mapper.Map<DokumentPrzyjeciaDto>(dokument);
    }
    public async Task ZatwierdzDokumentPrzyjeciaAsync(int dokumentPrzyjeciaId)
    {
        await _dokumentPrzyjeciaRepository.ZatwierdzDokumentPrzyjeciaAsync(dokumentPrzyjeciaId);
    }

    public async Task AnulujDokumentPrzyjeciaAsync(int dokumentPrzyjeciaId)
    {
        await _dokumentPrzyjeciaRepository.AnulujDokumentPrzyjeciaAsync(dokumentPrzyjeciaId);
    }
    public async Task UpdateAsync(DokumentPrzyjeciaUpdateDto dokumentUpdateDto)
    {
        await _dokumentPrzyjeciaRepository.UpdateAsync(dokumentUpdateDto);
    }
}
