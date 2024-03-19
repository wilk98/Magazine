using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Magazyn;

public class MagazynCreateDto
{
    [Required]
    public string Nazwa { get; set; }
    [Required]
    public string Symbol { get; set; }
}
