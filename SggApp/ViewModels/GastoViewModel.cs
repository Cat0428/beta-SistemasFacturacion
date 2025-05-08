using System;
using System.ComponentModel.DataAnnotations;

namespace SggApp.ViewModels
{
    public class GastoViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }

        [Required]
        public int CategoriaId { get; set; }

        public string CategoriaNombre { get; set; }
    }  
}


