namespace GestionRadio.Domain.Common;

/// <summary>
/// Clase base para entidades que requieren auditoría.
/// Todas las entidades del ERP heredarán de esta clase.
/// </summary>
public abstract class AuditableEntity : BaseEntity
{
    /// <summary>
    /// Indica si el registro está activo.
    /// </summary>
    public bool Activo { get; set; } = true;

    /// <summary>
    /// Fecha en que se creó el registro.
    /// </summary>
    public DateTime FechaAlta { get; set; } = DateTime.Now;

    /// <summary>
    /// Usuario que creó el registro.
    /// </summary>
    public int? UsuarioAlta { get; set; }

    /// <summary>
    /// Fecha de la última modificación.
    /// </summary>
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Usuario que realizó la última modificación.
    /// </summary>
    public int? UsuarioModificacion { get; set; }
}