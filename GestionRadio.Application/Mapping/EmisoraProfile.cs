using AutoMapper;
using GestionRadio.Application.DTOs.Emisora;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Mapping;

public sealed class EmisoraProfile : Profile
{
    public EmisoraProfile()
    {
        CreateMap<Emisora, EmisoraDto>();
    }
}