using System.ComponentModel.DataAnnotations;

namespace GestionRadio.Application.DTOs;

public sealed class ClienteUpdateDto
{
    [Required]
    public long IdCliente { get; set; }

    [Required(ErrorMessage = "La razón social es obligatoria.")]
    [MaxLength(200)]
    public string RazonSocial { get; set; } = string.Empty;

    [MaxLength(200)]
    public string? NombreComercial { get; set; }

    [MaxLength(13)]
    public string? RFC { get; set; }

    [MaxLength(100)]
    public string? RegimenFiscal { get; set; }

    [MaxLength(100)]
    public string? UsoCFDI { get; set; }

    [MaxLength(150)]
    public string? Contacto { get; set; }

    [MaxLength(20)]
    public string? Telefono { get; set; }

    [MaxLength(20)]
    public string? WhatsApp { get; set; }

    [EmailAddress]
    [MaxLength(150)]
    public string? Email { get; set; }

    [MaxLength(200)]
    public string? Calle { get; set; }

    [MaxLength(20)]
    public string? NumeroExterior { get; set; }

    [MaxLength(20)]
    public string? NumeroInterior { get; set; }

    [MaxLength(150)]
    public string? Colonia { get; set; }

    [MaxLength(100)]
    public string? Ciudad { get; set; }

    [MaxLength(100)]
    public string? Estado { get; set; }

    [MaxLength(10)]
    public string? CodigoPostal { get; set; }

    public decimal LimiteCredito { get; set; }

    public int DiasCredito { get; set; }

    public bool Activo { get; set; }
}