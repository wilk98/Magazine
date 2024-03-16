using Application.DTOs.DokumentPrzyjecia;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/dokumentyprzyjecia")]
[ApiController]
public class DokumentyPrzyjeciaController : ControllerBase
{
    private readonly IDokumentPrzyjeciaService _dokumentPrzyjeciaService;

    public DokumentyPrzyjeciaController(IDokumentPrzyjeciaService dokumentPrzyjeciaService)
    {
        _dokumentPrzyjeciaService = dokumentPrzyjeciaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DokumentPrzyjeciaDto>>> GetAll()
    {
        var dokumentyDto = await _dokumentPrzyjeciaService.GetAllAsync();
        return Ok(dokumentyDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DokumentPrzyjeciaDto>> Get(int id)
    {
        var dokumentDto = await _dokumentPrzyjeciaService.GetByIdAsync(id);
        if (dokumentDto == null) return NotFound();
        return Ok(dokumentDto);
    }

    [HttpPost]
    public async Task<ActionResult<DokumentPrzyjeciaDto>> Create([FromBody] DokumentPrzyjeciaCreateDto dokumentCreateDto)
    {
        var createdDokumentDto = await _dokumentPrzyjeciaService.AddAsync(dokumentCreateDto);
        return CreatedAtAction(nameof(Get), new { id = createdDokumentDto.DokumentPrzyjeciaId }, createdDokumentDto);
    }

}
