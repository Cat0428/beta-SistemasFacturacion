using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace SggApp.ViewModels
{
    public class PresupuestoViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Fecha de inicio")]
        public DateTime FechaInicio { get; set; }

        [Required]
        [Display(Name = "Fecha de fin")]
        public DateTime FechaFin { get; set; } = DateTime.Now.Date;


        [Required]
        [Display(Name = "Monto")]
        public decimal Monto { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public int UsuarioId { get; set; }

        public string? UsuarioNombre { get; set; }

        // ✅ Agrega esta propiedad
        public IEnumerable<SelectListItem>? Usuarios { get; set; }
    }
}
