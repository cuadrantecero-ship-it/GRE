namespace GestionRadio.Domain.Entities;

/// <summary>
/// Representa un material de audio almacenado en Dinesat.
/// Esta entidad es de solo lectura para GESTIÓN RADIO.
/// El audio permanece administrado por Dinesat.
/// </summary>
public sealed class DinesatMaterial
{
    /// <summary>
    /// Identificador interno del material en Dinesat.
    /// </summary>
    public long MaterialId { get; set; }

    /// <summary>
    /// Código del material (Ejemplo: SPO00004).
    /// </summary>
    public string Codigo { get; set; } = string.Empty;

    /// <summary>
    /// Título o descripción del material.
    /// </summary>
    public string Titulo { get; set; } = string.Empty;

    /// <summary>
    /// Duración del material en milisegundos,
    /// tal como la almacena Dinesat.
    /// </summary>
    public int Duracion { get; set; }

    /// <summary>
    /// Estado del material en Dinesat.
    /// 1 = Activo.
    /// </summary>
    public int MaterialStateId { get; set; }

    /// <summary>
    /// Indica si el material está disponible.
    /// </summary>
    public bool Activo => MaterialStateId == 1;
}