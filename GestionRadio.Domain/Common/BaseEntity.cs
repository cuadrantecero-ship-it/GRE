namespace GestionRadio.Domain.Common;

/// <summary>
/// Clase base para todas las entidades del dominio.
/// </summary>
public abstract class BaseEntity
{
    public virtual long Id { get; set; }
}