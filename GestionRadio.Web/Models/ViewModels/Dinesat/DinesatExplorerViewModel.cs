using GestionRadio.Domain.Entities;

namespace GestionRadio.Web.Models.ViewModels.Dinesat;

public sealed class DinesatExplorerViewModel
{
    /// <summary>
    /// Materiales cargados desde Dinesat.
    /// </summary>
    public IReadOnlyList<DinesatMaterial> Materiales { get; set; }
        = [];

    /// <summary>
    /// Categoría actualmente seleccionada.
    /// </summary>
    public string CategoriaSeleccionada { get; set; }
        = "SPOT";

    /// <summary>
    /// Material seleccionado.
    /// </summary>
    public DinesatMaterial? MaterialSeleccionado { get; set; }

    /// <summary>
    /// Texto de búsqueda.
    /// </summary>
    public string Buscar { get; set; }
        = string.Empty;
}