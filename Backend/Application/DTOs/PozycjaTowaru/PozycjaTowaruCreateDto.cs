using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.PozycjaTowaru;

public class PozycjaTowaruCreateDto
{
    [Required]
    public int Ilosc { get; set; }
    [Required]
    public decimal Cena { get; set; }
    [Required]
    public int TowarId { get; set; }
}
