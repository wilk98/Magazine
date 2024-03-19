using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PozycjaTowaru;

public class PozycjaTowaruUpdateDto
{
    [Required]
    public int PozycjaTowaruId { get; set; }
    [Required]
    public int Ilosc { get; set; }
    [Required]
    public decimal Cena { get; set; }
    [Required]
    public int TowarId { get; set; }
}
