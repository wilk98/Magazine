using Application.DTOs.Etykieta;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/etykiety")]
[ApiController]
public class EtykietyController : ControllerBase
{
    private readonly IEtykietaService _etykietaService;

    public EtykietyController(IEtykietaService etykietaService)
    {
        _etykietaService = etykietaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<EtykietaDto>>> GetAll()
    {
        var etykietyDto = await _etykietaService.GetAllAsync();
        return Ok(etykietyDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<EtykietaDto>> Get(int id)
    {
        var etykietaDto = await _etykietaService.GetByIdAsync(id);
        if (etykietaDto == null) return NotFound();
        return Ok(etykietaDto);
    }

    [HttpPost]
    public async Task<ActionResult<EtykietaDto>> Create([FromBody] EtykietaCreateDto etykietaCreateDto)
    {
        var createdEtykietaDto = await _etykietaService.AddAsync(etykietaCreateDto);
        return CreatedAtAction(nameof(Get), new { id = createdEtykietaDto.EtykietaId }, createdEtykietaDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] EtykietaDto etykietaDto)
    {
        if (id != etykietaDto.EtykietaId) return BadRequest("ID mismatch");
        await _etykietaService.UpdateAsync(etykietaDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _etykietaService.DeleteAsync(id);
        return NoContent();
    }
}
