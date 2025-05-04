using System.ComponentModel.DataAnnotations;

public class PresupuestoViewModel
{
    public int Id { get; set; }

    [Required]
    public decimal Monto { get; set; }

    [Required]
    public int Mes { get; set; }

    [Required]
    public int Anio { get; set; }

    public int UsuarioId { get; set; }
}
