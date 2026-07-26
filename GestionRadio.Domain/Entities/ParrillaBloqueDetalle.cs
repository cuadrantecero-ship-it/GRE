namespace GestionRadio.Domain.Entities;

public class ParrillaBloqueDetalle
{
    public long DetalleId { get; set; }

    public long BloqueId { get; set; }

    public int Orden { get; set; }

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

    public string? MaterialFijo { get; set; }

    public int DuracionMaxSegundos { get; set; }

    public bool Obligatorio { get; set; }

    public int Prioridad { get; set; }

    public bool Activo { get; set; }

    // Navegación
    public ParrillaBloque? Bloque { get; set; }
}