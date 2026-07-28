namespace GestionRadio.Domain.Entities;

public class ParrillaBloqueDetalle
{
    public long DetalleId { get; set; }

    public long BloqueId { get; set; }

    /// <summary>
    /// Orden del evento dentro del bloque.
    /// </summary>
    public int Orden { get; set; }

    /// <summary>
    /// Tipo de evento.
    /// </summary>
    public int TipoEventoId { get; set; }

    /// <summary>
    /// Fuente del material:
    /// 1 = Material Fijo
    /// 2 = Campaña
    /// 3 = Versión
    /// 4 = RTC
    /// 5 = INE
    /// 6 = Servicio Social
    /// 7 = Programa
    /// 8 = Identificación
    /// 9 = Hora
    /// 10 = Liner
    /// 11 = Autopromoción
    /// 12 = Música
    /// 13 = Scheduler
    /// </summary>
    public byte Fuente { get; set; }

    /// <summary>
    /// Código del material fijo en Dinesat.
    /// Ejemplo: SPO00001
    /// </summary>
    public string? MaterialFijo { get; set; }

    /// <summary>
    /// MaterialId correspondiente en Dinesat.
    /// </summary>
    public int? DinesatMaterialId { get; set; }

    /// <summary>
    /// Duración máxima permitida.
    /// </summary>
    public int DuracionMaxSegundos { get; set; }

    /// <summary>
    /// Duración real utilizada por el material.
    /// </summary>
    public int DuracionRealSegundos { get; set; }

    /// <summary>
    /// Indica si este espacio debe llenarse obligatoriamente.
    /// </summary>
    public bool Obligatorio { get; set; }

    /// <summary>
    /// Prioridad utilizada por el motor.
    /// </summary>
    public int Prioridad { get; set; }

    /// <summary>
    /// Permite reemplazo automático por el motor.
    /// </summary>
    public bool Reemplazable { get; set; }

    /// <summary>
    /// Indica si el registro está activo.
    /// </summary>
    public bool Activo { get; set; }

    // ==========================
    // Navegación
    // ==========================

    public ParrillaBloque? Bloque { get; set; }
}