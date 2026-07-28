using AutoMapper;
using GestionRadio.Application.DTOs.Parrilla;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Mapping;

public class ParrillaProfile : Profile
{
    public ParrillaProfile()
    {

        //=========================================
        // PARRILLA
        //=========================================

        CreateMap<Parrilla, ParrillaDto>();

        CreateMap<ParrillaCreateDto, Parrilla>();

        CreateMap<ParrillaUpdateDto, Parrilla>();



        //=========================================
        // EVENTOS
        //=========================================

        CreateMap<ParrillaEvento, ParrillaEventoDto>();


        CreateMap<ParrillaEventoCreateDto, ParrillaEvento>();


        CreateMap<ParrillaEventoUpdateDto, ParrillaEvento>();



        //=========================================
        // TIPOS EVENTO
        //=========================================

        CreateMap<TipoEvento, TipoEventoDto>();

    }
}