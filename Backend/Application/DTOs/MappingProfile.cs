using Application.DTOs.DokumentPrzyjecia;
using Application.DTOs.Dostawca;
using Application.DTOs.Etykieta;
using Application.DTOs.Magazyn;
using Application.DTOs.PozycjaTowaru;
using Application.DTOs.Towar;
using AutoMapper;
using Core;

namespace Application;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MagazynCreateDto, Magazyn>();
        CreateMap<MagazynDto, Magazyn>();
        CreateMap<Magazyn, MagazynDto>();

        CreateMap<DostawcaCreateDto, Dostawca>();
        CreateMap<DostawcaDto, Dostawca>();
        CreateMap<Dostawca, DostawcaDto>();

        CreateMap<TowarCreateDto, Towar>();
        CreateMap<TowarDto, Towar>();
        CreateMap<Towar, TowarDto>();

        CreateMap<EtykietaCreateDto, Etykieta>();
        CreateMap<EtykietaDto, Etykieta>();
        CreateMap<Etykieta, EtykietaDto>();

        CreateMap<DokumentPrzyjeciaCreateDto, DokumentPrzyjecia>();
        CreateMap<DokumentPrzyjeciaDto, DokumentPrzyjecia>();
        CreateMap<DokumentPrzyjecia, DokumentPrzyjeciaDto>();

        CreateMap<PozycjaTowaruCreateDto, PozycjaTowaru>();
        CreateMap<PozycjaTowaruDto, PozycjaTowaru>();
        CreateMap<PozycjaTowaru, PozycjaTowaruDto>();
    }
}
