using GestionRadio.Application.Models;

namespace GestionRadio.Application.Interfaces;

/// <summary>
/// Contrato del Motor Inteligente de Rotación.
/// </summary>
public interface IRotationEngineService
{
    /// <summary>
    /// Selecciona automáticamente la mejor versión
    /// para una campaña según las reglas del motor.
    /// </summary>
    Task<RotationResult> SeleccionarVersionAsync(RotationRequest request);
}