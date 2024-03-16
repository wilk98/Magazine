using Application.DTOs.Towar;

namespace Application.DTOs.PozycjaTowaru;

public class PozycjaTowaruDto
{
    public int PozycjaTowaruId { get; set; }
    public int Ilosc { get; set; }
    public decimal Cena { get; set; }
    public int TowarId { get; set; }
    public TowarDto Towar { get; set; }
}