using Application.DTOs.PozycjaTowaru;
using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.DokumentPrzyjecia;

public class DokumentPrzyjeciaUpdateDto
{
    [Required]
    public int DokumentPrzyjeciaId { get; set; }
    [Required]
    public DateTime DataPrzyjecia { get; set; }
    [Required]
    public int MagazynId { get; set; }
    [Required]
    public int DostawcaId { get; set; }
    [Required]
    public List<int> EtykietyIds { get; set; }
    [Required]
    public List<PozycjaTowaruUpdateDto> PozycjeTowaru { get; set; }
}