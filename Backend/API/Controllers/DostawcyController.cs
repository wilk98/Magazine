using Application.DTOs.Dostawca;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/dostawcy")]
[ApiController]
public class DostawcyController : ControllerBase
{
    private readonly IDostawcaService _dostawcaService;

    public DostawcyController(IDostawcaService dostawcaService)
    {
        _dostawcaService = dostawcaService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DostawcaDto>>> GetAll()
    {
        var dostawcyDto = await _dostawcaService.GetAllAsync();
        return Ok(dostawcyDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DostawcaDto>> Get(int id)
    {
        var dostawcaDto = await _dostawcaService.GetByIdAsync(id);
        if (dostawcaDto == null) return NotFound();
        return Ok(dostawcaDto);
    }

    [HttpPost]
    public async Task<ActionResult<DostawcaDto>> Create([FromBody] DostawcaCreateDto dostawcaCreateDto)
    {
        var createdDostawcaDto = await _dostawcaService.AddAsync(dostawcaCreateDto);
        return CreatedAtAction(nameof(Get), new { id = createdDostawcaDto.DostawcaId }, createdDostawcaDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] DostawcaDto dostawcaDto)
    {
        if (id != dostawcaDto.DostawcaId) return BadRequest("ID mismatch");
        await _dostawcaService.UpdateAsync(dostawcaDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _dostawcaService.DeleteAsync(id);
        return NoContent();
    }
}
