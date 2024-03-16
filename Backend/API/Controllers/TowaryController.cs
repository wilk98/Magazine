using Application.DTOs.Towar;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/towary")]
[ApiController]
public class TowaryController : ControllerBase
{
    private readonly ITowarService _towarService;

    public TowaryController(ITowarService towarService)
    {
        _towarService = towarService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TowarDto>>> GetAll()
    {
        var towaryDto = await _towarService.GetAllAsync();
        return Ok(towaryDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<TowarDto>> Get(int id)
    {
        var towarDto = await _towarService.GetByIdAsync(id);
        if (towarDto == null) return NotFound();
        return Ok(towarDto);
    }

    [HttpPost]
    public async Task<ActionResult<TowarDto>> Create([FromBody] TowarCreateDto towarCreateDto)
    {
        var createdTowarDto = await _towarService.AddAsync(towarCreateDto);
        return CreatedAtAction(nameof(Get), new { id = createdTowarDto.TowarId }, createdTowarDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] TowarDto towarDto)
    {
        if (id != towarDto.TowarId) return BadRequest("ID mismatch");
        await _towarService.UpdateAsync(towarDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _towarService.DeleteAsync(id);
        return NoContent();
    }
}
