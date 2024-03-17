using Application.DTOs.DokumentPrzyjecia;
using Application.Interfaces.Repositories;
using Core;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

public class DokumentPrzyjeciaRepository : IDokumentPrzyjeciaRepository
{
    private readonly AppDbContext _context;

    public DokumentPrzyjeciaRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<DokumentPrzyjecia>> GetAllAsync()
    {
        return await _context.DokumentyPrzyjecia
            .Where(d => d.StatusZatwierdzenia != false)
            .Include(d => d.Magazyn)
            .Include(d => d.Dostawca)
            .Include(d => d.PozycjeTowaru)
                .ThenInclude(p => p.Towar)
            .Include(d => d.Etykiety)
            .ToListAsync();
    }

    public async Task<DokumentPrzyjecia> GetByIdAsync(int id)
    {
        return await _context.DokumentyPrzyjecia
            .Include(d => d.Magazyn)
            .Include(d => d.Dostawca)
            .Include(d => d.PozycjeTowaru)
                .ThenInclude(p => p.Towar)
            .Include(d => d.Etykiety)
            .FirstOrDefaultAsync(d => d.DokumentPrzyjeciaId == id);
    }


    public async Task<DokumentPrzyjecia> AddAsync(DokumentPrzyjecia dokumentPrzyjecia, List<int> etykietyIds = null)
    {
        if (etykietyIds != null && etykietyIds.Count > 0)
        {
            var etykiety = await _context.Etykiety.Where(e => etykietyIds.Contains(e.EtykietaId)).ToListAsync();
            foreach (var etykieta in etykiety)
            {
                dokumentPrzyjecia.Etykiety.Add(etykieta);
            }
        }

        await _context.DokumentyPrzyjecia.AddAsync(dokumentPrzyjecia);
        await _context.SaveChangesAsync();

        return dokumentPrzyjecia;
    }

    public async Task ZatwierdzDokumentPrzyjeciaAsync(int dokumentPrzyjeciaId)
    {
        var dokument = await _context.DokumentyPrzyjecia.FindAsync(dokumentPrzyjeciaId);
        if (dokument != null)
        {
            dokument.StatusZatwierdzenia = true;
            await _context.SaveChangesAsync();
        }
    }

    public async Task AnulujDokumentPrzyjeciaAsync(int dokumentPrzyjeciaId)
    {
        var dokument = await _context.DokumentyPrzyjecia.FindAsync(dokumentPrzyjeciaId);
        if (dokument != null)
        {
            dokument.StatusZatwierdzenia = false;
            await _context.SaveChangesAsync();
        }
    }
    public async Task UpdateAsync(DokumentPrzyjeciaUpdateDto dokumentUpdateDto)
    {
        var dokument = await _context.DokumentyPrzyjecia
                                     .Include(d => d.Etykiety)
                                     .Include(d => d.PozycjeTowaru)
                                     .ThenInclude(p => p.Towar)
                                     .FirstOrDefaultAsync(d => d.DokumentPrzyjeciaId == dokumentUpdateDto.DokumentPrzyjeciaId);

        if (dokument == null)
        {
            throw new Exception("Nie znaleziono dokumentu.");
        }

        if (dokument.StatusZatwierdzenia == true)
        {
            throw new Exception("Nie można aktualizować zatwierdzonego dokumentu.");
        }

        dokument.DataPrzyjecia = dokumentUpdateDto.DataPrzyjecia;
        dokument.MagazynId = dokumentUpdateDto.MagazynId;
        dokument.DostawcaId = dokumentUpdateDto.DostawcaId;

        var noweEtykiety = await _context.Etykiety
                                         .Where(e => dokumentUpdateDto.EtykietyIds.Contains(e.EtykietaId))
                                         .ToListAsync();
        dokument.Etykiety.Clear();
        foreach (var etykieta in noweEtykiety)
        {
            dokument.Etykiety.Add(etykieta);
        }

        foreach (var pozycjaDto in dokumentUpdateDto.PozycjeTowaru)
        {
            var pozycja = dokument.PozycjeTowaru.FirstOrDefault(p => p.PozycjaTowaruId == pozycjaDto.PozycjaTowaruId);

            if (pozycja != null)
            {
                pozycja.Ilosc = pozycjaDto.Ilosc;
                pozycja.Cena = pozycjaDto.Cena;
            }
            else
            {
                dokument.PozycjeTowaru.Add(new PozycjaTowaru
                {
                    Ilosc = pozycjaDto.Ilosc,
                    Cena = pozycjaDto.Cena,
                    TowarId = pozycjaDto.TowarId,
                    DokumentPrzyjeciaId = dokument.DokumentPrzyjeciaId
                });
            }
        }

        _context.DokumentyPrzyjecia.Update(dokument);
        await _context.SaveChangesAsync();
    }

}
