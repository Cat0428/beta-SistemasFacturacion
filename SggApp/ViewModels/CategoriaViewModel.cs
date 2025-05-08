using System.ComponentModel.DataAnnotations;

namespace SggApp.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }
    }
}

