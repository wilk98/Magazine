using Application.DTOs.PozycjaTowaru;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DokumentPrzyjecia;

public class DokumentPrzyjeciaCreateDto
{
    [Required]
    public DateTime DataPrzyjecia { get; set; }
    [Required]
    public int MagazynId { get; set; }
    [Required]
    public int DostawcaId { get; set; }
    [Required]
    public ICollection<int> EtykietyIds { get; set; }
    [Required]
    public ICollection<PozycjaTowaruCreateDto> PozycjeTowaru { get; set; }
}
