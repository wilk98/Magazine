using Application.DTOs.PozycjaTowaru;

namespace Application.DTOs.DokumentPrzyjecia;

public class DokumentPrzyjeciaCreateDto
{
    public DateTime DataPrzyjecia { get; set; }

    public int MagazynId { get; set; }
    public int DostawcaId { get; set; }

    public ICollection<int> EtykietyIds { get; set; }
    public ICollection<PozycjaTowaruCreateDto> PozycjeTowaru { get; set; }
}
