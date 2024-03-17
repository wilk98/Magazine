namespace Core;

public class DokumentPrzyjecia
{
    public DokumentPrzyjecia()
    {
        Etykiety = new HashSet<Etykieta>();
        StatusZatwierdzenia = null;
        PozycjeTowaru = new List<PozycjaTowaru>();
    }

    public int DokumentPrzyjeciaId { get; set; }
    public DateTime DataPrzyjecia { get; set; }

    public int MagazynId { get; set; }
    public Magazyn Magazyn { get; set; }

    public int DostawcaId { get; set; }
    public Dostawca Dostawca { get; set; }

    // Relacja wiele do wielu z Etykieta
    public ICollection<Etykieta> Etykiety { get; set; }

    // Relacja jeden do wielu z Towar
    public ICollection<PozycjaTowaru> PozycjeTowaru { get; set; }
    public bool? StatusZatwierdzenia { get; set; }
}
