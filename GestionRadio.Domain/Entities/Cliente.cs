namespace GestionRadio.Domain.Entities;

public class Cliente
{
    public long IdCliente { get; set; }

    // Coincide con GR_CLIENTE.FOLIO
    public string Folio { get; set; } = string.Empty;

    public int? DinesatCompanyId { get; set; }

    public string RazonSocial { get; set; } = string.Empty;

    public string? NombreComercial { get; set; }

    public string? RFC { get; set; }

    public string? RegimenFiscal { get; set; }

    public string? UsoCFDI { get; set; }

    public string? Contacto { get; set; }

    public string? Telefono { get; set; }

    public string? WhatsApp { get; set; }

    public string? Email { get; set; }

    public string? Calle { get; set; }

    public string? NumeroExterior { get; set; }

    public string? NumeroInterior { get; set; }

    public string? Colonia { get; set; }

    public string? Ciudad { get; set; }

    public string? Estado { get; set; }

    public string? CodigoPostal { get; set; }

    public decimal LimiteCredito { get; set; }

    public int DiasCredito { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaAlta { get; set; }

    public int? UsuarioAlta { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public int? UsuarioModificacion { get; set; }
}