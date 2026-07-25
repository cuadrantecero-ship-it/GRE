namespace GestionRadio.Application.Models;

/// <summary>
/// Resultado del Motor Inteligente de Rotación.
/// Contiene la versión seleccionada y la información
/// utilizada para tomar la decisión.
/// </summary>
public sealed class RotationResult
{
    /// <summary>
    /// Indica si la selección fue exitosa.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Identificador de la versión seleccionada.
    /// </summary>
    public long VersionId { get; set; }

    /// <summary>
    /// Material Dinesat que debe programarse.
    /// Ejemplo: SPO00003
    /// </summary>
    public string MaterialCode { get; set; } = string.Empty;

    /// <summary>
    /// Nombre de la versión elegida.
    /// </summary>
    public string VersionName { get; set; } = string.Empty;

    /// <summary>
    /// Regla utilizada para seleccionar la versión.
    /// </summary>
    public string RuleApplied { get; set; } = string.Empty;

    /// <summary>
    /// Mensaje descriptivo del resultado.
    /// </summary>
    public string Message { get; set; } = string.Empty;
}