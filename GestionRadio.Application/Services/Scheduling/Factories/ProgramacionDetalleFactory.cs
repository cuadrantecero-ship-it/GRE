using GestionRadio.Application.Services.Scheduling.Models;
using GestionRadio.Domain.Entities;

namespace GestionRadio.Application.Services.Scheduling.Factories;

/// <summary>
/// Construye una entidad ProgramacionDetalle lista para persistirse.
/// </summary>
public sealed class ProgramacionDetalleFactory
{
    public ProgramacionDetalle Crear(
        Programacion programacion,
        TimelineBlock block,
        CampaignCandidate campaign,
        VersionCampania version,
        int orden)
    {
        ArgumentNullException.ThrowIfNull(programacion);
        ArgumentNullException.ThrowIfNull(block);
        ArgumentNullException.ThrowIfNull(campaign);
        ArgumentNullException.ThrowIfNull(version);

        return new ProgramacionDetalle
        {
            //==================================================
            // RELACIONES
            //==================================================

            ProgramacionId = programacion.ProgramacionId,

            ClienteId = campaign.ClienteId,
            CampaniaId = campaign.CampaniaId,
            VersionId = version.IdVersion,

            //==================================================
            // EVENTO DE PARRILLA
            //==================================================

            EventoParrillaId = block.EventoId,
            Hora = block.Hora,
            Orden = orden,

            //==================================================
            // DINESAT
            //==================================================

            DinesatMaterialId = version.MaterialIdDinesat,

            //==================================================
            // MATERIAL
            //==================================================

            CodigoMaterial = version.CodigoMaterial,
            TituloMaterial = version.TituloMaterial,
            DuracionSegundos = version.DuracionSegundos,

            //==================================================
            // ESTADO
            //==================================================

            Estado = 1,
            Activo = true,
            Sincronizado = false,
            Transmitido = false,

            //==================================================
            // AUDITORÍA
            //==================================================

            FechaCreacion = DateTime.Now,
            UsuarioCreacion = "SCHEDULER"
        };
    }
}