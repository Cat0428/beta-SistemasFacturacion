using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SggApp.ViewModels
{
    public class GastoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        [Required]
        public int MonedaId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public string CategoriaNombre { get; set; }
        public string MonedaNombre { get; set; }
        public string UsuarioNombre { get; set; }

        // 👇 Para los dropdowns en las vistas Create y Edit
        public IEnumerable<SelectListItem> Categorias { get; set; }
        public IEnumerable<SelectListItem> Monedas { get; set; }
        public IEnumerable<SelectListItem> Usuarios { get; set; }
    }
}
    