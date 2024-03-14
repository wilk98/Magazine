namespace Core;

public class Dostawca
{
    public int DostawcaId { get; set; }
    public string NazwaFirmy { get; set; }
    public string Adres { get; set; }

    // Relacje
    public ICollection<DokumentPrzyjecia> DokumentyPrzyjecia { get; set; }
}

