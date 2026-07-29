using AutoMapper;
using GestionRadio.Application.DTOs.Versiones;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Mapping;

public sealed class VersionProfile : Profile
{
    public VersionProfile()
    {
        CreateMap<VersionCampania, VersionDto>();

        CreateMap<VersionCreateDto, VersionCampania>();

        CreateMap<VersionUpdateDto, VersionCampania>();
    }
}