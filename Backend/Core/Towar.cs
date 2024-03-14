namespace Core;

public class Towar
{
    public int TowarId { get; set; }
    public string Nazwa { get; set; }
    public string Kod { get; set; }

    // Relacje
    public ICollection<PozycjaTowaru> PozycjeTowaru { get; set; }
}

