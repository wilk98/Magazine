using Application.DTOs.Magazyn;
using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

[Route("api/magazyny")]
[ApiController]
public class MagazynyController : ControllerBase
{
    private readonly IMagazynService _magazynService;

    public MagazynyController(IMagazynService magazynService)
    {
        _magazynService = magazynService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<MagazynDto>>> GetAll()
    {
        var magazynyDto = await _magazynService.GetAllAsync();
        return Ok(magazynyDto);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<MagazynDto>> Get(int id)
    {
        var magazynDto = await _magazynService.GetByIdAsync(id);
        if (magazynDto == null) return NotFound();
        return Ok(magazynDto);
    }

    [HttpPost]
    public async Task<ActionResult<MagazynDto>> Create([FromBody] MagazynCreateDto magazynCreateDto)
    {
        var createdMagazynDto = await _magazynService.AddAsync(magazynCreateDto);
        return CreatedAtAction(nameof(Get), new { id = createdMagazynDto.MagazynId }, createdMagazynDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] MagazynDto magazynUpdateDto)
    {
        if (id != magazynUpdateDto.MagazynId) return BadRequest("ID mismatch");

        await _magazynService.UpdateAsync(magazynUpdateDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _magazynService.DeleteAsync(id);
        return NoContent();
    }
}
