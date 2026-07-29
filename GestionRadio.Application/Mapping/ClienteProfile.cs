using AutoMapper;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.DTOs.Parrilla;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Mapping;

public sealed class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        //=========================================
        // CLIENTES
        //=========================================

        CreateMap<Cliente, ClienteDto>();


        //=========================================
        // CAMPAÑAS
        //=========================================

        CreateMap<Campania, CampaniaDto>();


        //=========================================
        // PARRILLAS
        //=========================================

        CreateMap<Parrilla, ParrillaDto>();

        CreateMap<ParrillaCreateDto, Parrilla>();

        CreateMap<ParrillaUpdateDto, Parrilla>();


        //=========================================
        // EVENTOS DE PARRILLA
        //=========================================

        CreateMap<ParrillaEvento, ParrillaEventoDto>();

        CreateMap<ParrillaEventoUpdateDto, ParrillaEvento>();
    }
}