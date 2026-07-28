namespace GestionRadio.Domain.Entities;

public class ParrillaBloque
{
    public long BloqueId { get; set; }

    public long ParrillaId { get; set; }

    /// <summary>
    /// Orden del bloque dentro de la parrilla.
    /// </summary>
    public int Orden { get; set; }

    /// <summary>
    /// Hora de inicio del bloque.
    /// </summary>
    public TimeOnly Hora { get; set; }

    /// <summary>
    /// Tipo de evento del bloque.
    /// </summary>
    public int TipoEventoId { get; set; }

    /// <summary>
    /// Programa asociado (si aplica).
    /// </summary>
    public int? ProgramaId { get; set; }

    /// <summary>
    /// Descripción del bloque.
    /// </summary>
    public string? Descripcion { get; set; }

    /// <summary>
    /// Duración máxima permitida para el bloque.
    /// </summary>
    public int DuracionMaximaSegundos { get; set; }

    /// <summary>
    /// Duración utilizada por los eventos generados.
    /// Se calcula durante la generación de la programación.
    /// </summary>
    public int DuracionUtilizadaSegundos { get; set; }

    /// <summary>
    /// Indica si el bloque permite insertar publicidad.
    /// </summary>
    public bool PermitePublicidad { get; set; }

    /// <summary>
    /// Indica si el bloque es obligatorio.
    /// </summary>
    public bool EsObligatorio { get; set; }

    /// <summary>
    /// Prioridad del bloque para el motor.
    /// </summary>
    public int Prioridad { get; set; }

    /// <summary>
    /// Máscara de días:
    /// Lunes=1
    /// Martes=2
    /// Miércoles=4
    /// Jueves=8
    /// Viernes=16
    /// Sábado=32
    /// Domingo=64
    /// 127 = Todos los días
    /// </summary>
    public byte DiasSemana { get; set; }

    /// <summary>
    /// Comportamiento del bloque.
    /// 1 = Fijo
    /// 2 = Comercial
    /// 3 = Programa
    /// 4 = Informativo
    /// 5 = Flexible
    /// 6 = Especial
    /// </summary>
    public byte Comportamiento { get; set; }

    /// <summary>
    /// Identificador del bloque correspondiente en Dinesat.
    /// Se llena durante la sincronización.
    /// </summary>
    public int? DinesatProgramBlockId { get; set; }

    /// <summary>
    /// Permite edición manual por el continuista.
    /// </summary>
    public bool Editable { get; set; }

    public bool Activo { get; set; }

    // ==========================
    // Navegación
    // ==========================

    public Parrilla? Parrilla { get; set; }

    public ICollection<ParrillaBloqueDetalle> Detalles { get; set; }
        = new List<ParrillaBloqueDetalle>();
}