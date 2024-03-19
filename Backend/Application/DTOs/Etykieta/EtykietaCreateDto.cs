using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Etykieta;

public class EtykietaCreateDto
{
    [Required]
    public string Nazwa { get; set; }
}
