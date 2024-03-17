namespace Application.DTOs.PozycjaTowaru;

public class PozycjaTowaruUpdateDto
{
    public int PozycjaTowaruId { get; set; }
    public int Ilosc { get; set; }
    public decimal Cena { get; set; }
    public int TowarId { get; set; }
}
