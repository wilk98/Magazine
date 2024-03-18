using Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class PozycjeTowaruController : ControllerBase
{
    private readonly IPozycjaTowaruService _pozycjeTowaruService;

    public PozycjeTowaruController(IPozycjaTowaruService pozycjeTowaruService)
    {
        _pozycjeTowaruService = pozycjeTowaruService;
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePozycjaTowaru(int id)
    {
        await _pozycjeTowaruService.DeleteAsync(id);
        return Ok();

    }
}
