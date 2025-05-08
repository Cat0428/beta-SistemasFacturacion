using System.ComponentModel.DataAnnotations;

namespace SggApp.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required] public string Nombre { get; set; }

        [Required, EmailAddress] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}