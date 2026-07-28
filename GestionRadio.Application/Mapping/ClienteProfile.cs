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
        // CLIENTE
        //=========================================

        CreateMap<Cliente, ClienteDto>();



        //=========================================
        // PARRILLA
        //=========================================

        CreateMap<Parrilla, ParrillaDto>();

        CreateMap<ParrillaCreateDto, Parrilla>();

        CreateMap<ParrillaUpdateDto, Parrilla>();


        //=========================================
        // EVENTOS PARRILLA
        //=========================================

        CreateMap<ParrillaEvento, ParrillaEventoDto>();

        CreateMap<ParrillaEventoUpdateDto, Parrilla>();

    }
}