using AutoMapper;
using GestionRadio.Application.DTOs.Programacion;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Mapping;

public class ProgramacionProfile : Profile
{
    public ProgramacionProfile()
    {
        // Entity -> DTO
        CreateMap<Programacion, ProgramacionDto>();

        // DTO -> Entity
        CreateMap<ProgramacionCreateDto, Programacion>();

        // Entity -> Entity
        CreateMap<Programacion, Programacion>()
            .ForMember(d => d.ProgramacionId, o => o.Ignore())
            .ForMember(d => d.Detalles, o => o.Ignore());
    }
}