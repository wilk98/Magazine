namespace Core;

public class Magazyn
{
    public int MagazynId { get; set; }
    public string Nazwa { get; set; }
    public string Symbol { get; set; }

    // Relacje
    public ICollection<DokumentPrzyjecia> DokumentyPrzyjecia { get; set; }
}
