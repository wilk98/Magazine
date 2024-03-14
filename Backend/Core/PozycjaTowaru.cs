namespace Core;

public class PozycjaTowaru
{
    public int PozycjaTowaruId { get; set; }
    public int Ilosc { get; set; }
    public decimal Cena { get; set; }

    public int TowarId { get; set; }
    public Towar Towar { get; set; }

    public int DokumentPrzyjeciaId { get; set; }
    public DokumentPrzyjecia DokumentPrzyjecia { get; set; }
}

