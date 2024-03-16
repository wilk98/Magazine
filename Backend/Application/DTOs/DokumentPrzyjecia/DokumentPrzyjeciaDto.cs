using Application.DTOs.Dostawca;
using Application.DTOs.Etykieta;
using Application.DTOs.Magazyn;
using Application.DTOs.PozycjaTowaru;

namespace Application.DTOs.DokumentPrzyjecia;

public class DokumentPrzyjeciaDto
{
    public int DokumentPrzyjeciaId { get; set; }
    public DateTime DataPrzyjecia { get; set; }
    public int MagazynId { get; set; }
    public MagazynDto Magazyn { get; set; }
    public int DostawcaId { get; set; }
    public DostawcaDto Dostawca { get; set; }
    public List<PozycjaTowaruDto> PozycjeTowaru { get; set; }
    public List<EtykietaDto> Etykiety { get; set; }
}
