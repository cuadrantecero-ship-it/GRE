using AutoMapper;
using GestionRadio.Application.DTOs;
using GestionRadio.Application.DTOs.Parrillas;
using GestionRadio.Application.DTOs.Versiones;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Mapping;

public sealed class ClienteProfile : Profile
{
    public ClienteProfile()
    {
        // ==========================
        // CLIENTES
        // ==========================

        CreateMap<Cliente, ClienteDto>();
        CreateMap<ClienteCreateDto, Cliente>();
        CreateMap<ClienteUpdateDto, Cliente>();
        CreateMap<Cliente, ClienteUpdateDto>();

        // ==========================
        // CAMPAÑAS
        // ==========================

        CreateMap<Campania, CampaniaDto>();
        CreateMap<CampaniaCreateDto, Campania>();
        CreateMap<CampaniaUpdateDto, Campania>();
        CreateMap<Campania, CampaniaUpdateDto>();

        // ==========================
        // VERSIONES
        // ==========================

        CreateMap<VersionCampania, VersionDto>();
        CreateMap<VersionCreateDto, VersionCampania>();
        CreateMap<VersionUpdateDto, VersionCampania>();
        CreateMap<VersionCampania, VersionUpdateDto>();

        // ==========================
        // PARRILLAS
        // ==========================

        CreateMap<Parrilla, ParrillaDto>();
        CreateMap<ParrillaCreateDto, Parrilla>();
        CreateMap<ParrillaUpdateDto, Parrilla>();
        CreateMap<Parrilla, ParrillaUpdateDto>();

        // ==========================
        // EVENTOS DE PARRILLA
        // ==========================

        CreateMap<ParrillaEvento, ParrillaEventoDto>();
        CreateMap<ParrillaEventoCreateDto, ParrillaEvento>();
        CreateMap<ParrillaEventoUpdateDto, ParrillaEvento>();
        CreateMap<ParrillaEvento, ParrillaEventoUpdateDto>();

        // ==========================
        // TIPOS DE EVENTO
        // ==========================

        CreateMap<TipoEvento, TipoEventoDto>();
    }
}