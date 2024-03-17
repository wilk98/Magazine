using Application.DTOs.PozycjaTowaru;

namespace Application.DTOs.DokumentPrzyjecia;

public class DokumentPrzyjeciaUpdateDto
{
    public int DokumentPrzyjeciaId { get; set; }
    public DateTime DataPrzyjecia { get; set; }
    public int MagazynId { get; set; }
    public int DostawcaId { get; set; }
    public List<int> EtykietyIds { get; set; }
    public List<PozycjaTowaruUpdateDto> PozycjeTowaru { get; set; }
}