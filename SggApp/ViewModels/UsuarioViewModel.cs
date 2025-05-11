using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;


namespace SggApp.ViewModels
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }

        [Required] public string Nombre { get; set; }

        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailAvailable", controller: "Usuarios", AdditionalFields = "Id", ErrorMessage = "Este correo ya está registrado por otro usuario")]
        public string Email { get; set; }


        [Required] public string Password { get; set; }
    }
}