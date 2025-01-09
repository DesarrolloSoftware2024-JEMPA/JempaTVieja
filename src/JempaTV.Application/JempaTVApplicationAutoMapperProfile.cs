using AutoMapper;
using JempaTV.Califications;
using JempaTV.Series;

namespace JempaTV;

public class JempaTVApplicationAutoMapperProfile : Profile
{
    public JempaTVApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<CalificationDto, Calification>();
        CreateMap<Calification, CalificationDto>();
        CreateMap<Serie, SerieDto>();
        CreateMap<SerieDto, Serie>();
    }
}
