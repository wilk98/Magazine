using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Towar;

public class TowarCreateDto
{
    [Required]
    public string Nazwa { get; set; }
    [Required]
    public string Kod { get; set; }
}
