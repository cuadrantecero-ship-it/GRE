namespace GestionRadio.Domain.Entities;

public class ParrillaBloque
{
    public long BloqueId { get; set; }

    public long ParrillaId { get; set; }

    public int Orden { get; set; }

    public TimeOnly Hora { get; set; }

    public int TipoEventoId { get; set; }

    public int? ProgramaId { get; set; }

    public string? Descripcion { get; set; }

    public int DuracionMaximaSegundos { get; set; }

    public bool PermitePublicidad { get; set; }

    public bool EsObligatorio { get; set; }

    public int Prioridad { get; set; }

    /// <summary>
    /// Máscara de días:
    /// Lunes=1, Martes=2, Miércoles=4,
    /// Jueves=8, Viernes=16, Sábado=32, Domingo=64
    /// 127 = Todos los días
    /// </summary>
    public byte DiasSemana { get; set; }

    /// <summary>
    /// 1=Fijo
    /// 2=Comercial
    /// 3=Programa
    /// 4=Informativo
    /// 5=Flexible
    /// 6=Especial
    /// </summary>
    public byte Comportamiento { get; set; }

    public bool Editable { get; set; }

    public bool Activo { get; set; }

    // Navegación
    public Parrilla? Parrilla { get; set; }

    public ICollection<ParrillaBloqueDetalle> Detalles { get; set; }
        = new List<ParrillaBloqueDetalle>();
}