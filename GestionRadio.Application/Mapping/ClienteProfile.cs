using AutoMapper;
using GestionRadio.Application.DTOs;
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
    }
}