using AutoMapper;
using Core;

namespace Application.DTOs;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<MagazynCreateDto, Magazyn>();
        CreateMap<DostawcaCreateDto, Dostawca>();
        CreateMap<TowarCreateDto, Towar>();
        CreateMap<EtykietaCreateDto, Etykieta>();
        CreateMap<DokumentPrzyjeciaCreateDto, DokumentPrzyjecia>()
            .ForMember(dest => dest.PozycjeTowaru, opt => opt.MapFrom(src => src.PozycjeTowaru))
            .ForMember(dest => dest.Etykiety, opt => opt.Ignore());
        CreateMap<PozycjaTowaruCreateDto, PozycjaTowaru>();
    }
}
