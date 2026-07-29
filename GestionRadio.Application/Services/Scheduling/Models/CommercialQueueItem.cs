namespace GestionRadio.Application.Services.Scheduling.Models;

/// <summary>
/// Representa un elemento pendiente dentro de la cola comercial
/// que utilizará el Scheduler para distribuir campañas.
/// </summary>
public sealed class CommercialQueueItem
{
    //==========================================================
    // CAMPAÑA
    //==========================================================

    /// <summary>
    /// Campaña asociada a este elemento de la cola.
    /// Contiene toda la información necesaria para generar
    /// posteriormente el ProgramacionDetalle.
    /// </summary>
    public CampaignCandidate Campaign { get; set; } = default!;

    //==========================================================
    // CONTROL DE LA COLA
    //==========================================================

    /// <summary>
    /// Número total de inserciones pendientes.
    /// </summary>
    public int Pendientes { get; set; }

    /// <summary>
    /// Número de inserciones ya utilizadas.
    /// </summary>
    public int Utilizadas { get; set; }

    /// <summary>
    /// Indica si todas las inserciones ya fueron utilizadas.
    /// </summary>
    public bool Terminada => Utilizadas >= Pendientes;

    //==========================================================
    // PROPIEDADES DE ACCESO RÁPIDO
    //==========================================================

    public long ClienteId => Campaign.ClienteId;

    public long CampaniaId => Campaign.CampaniaId;

    public string NombreCampania => Campaign.NombreCampania;

    public byte Prioridad => Campaign.Prioridad;
}