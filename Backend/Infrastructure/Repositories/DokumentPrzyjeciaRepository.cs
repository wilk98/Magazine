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



}
