using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace SggApp.ViewModels
{
    public class GastoViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; } = DateTime.Today;

        [Required(ErrorMessage = "El monto es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El monto debe ser mayor que cero.")]
        public decimal Monto { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public int CategoriaId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar una moneda.")]
        public int MonedaId { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un usuario.")]
        public int UsuarioId { get; set; }

        public string CategoriaNombre { get; set; } = string.Empty;
        public string MonedaNombre { get; set; } = string.Empty;
        public string UsuarioNombre { get; set; } = string.Empty;

        // Para listas desplegables
        public IEnumerable<SelectListItem> Categorias { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Monedas { get; set; } = new List<SelectListItem>();
        public IEnumerable<SelectListItem> Usuarios { get; set; } = new List<SelectListItem>();
    }
}
