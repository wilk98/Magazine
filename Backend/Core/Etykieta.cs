namespace Core;

public class Etykieta
{
    public int EtykietaId { get; set; }
    public string Nazwa { get; set; }

    // Relacje wiele do wielu z DokumentPrzyjecia
    public ICollection<DokumentPrzyjecia> DokumentyPrzyjecia { get; set; }
}
