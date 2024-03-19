using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Dostawca;

public class DostawcaCreateDto
{
    [Required]
    public string NazwaFirmy { get; set; }
    [Required]
    public string Adres { get; set; }
}
