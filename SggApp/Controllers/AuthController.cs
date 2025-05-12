using SistemaFactura.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SggApp.ViewModels;
using SistemaFactura.BLL.Interfaces;
using System.Security.Claims;

namespace SggApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public AuthController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = await _usuarioService.LoginAsync(model.Email, model.Password);
            if (usuario == null)
            {
                ModelState.AddModelError("", "Correo o contraseña inválidos.");
                return View(model);
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol ?? "Usuario")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

            return Redirect(model.ReturnUrl ?? "/");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Auth");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            var usuario = new Usuario
            {
                Nombre = model.Nombre,
                Email = model.Email,
                Password = model.Password,
                Rol = "Usuario"
            };

            try
            {
                await _usuarioService.CreateAsync(usuario);
                return RedirectToAction("Login");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError("", ex.Message); // Muestra "Ya existe un usuario con ese correo electrónico."
                return View(model);
            }
        }

        [HttpGet]
        public async Task<JsonResult> IsEmailAvailable(string email)
        {
            var usuarios = await _usuarioService.GetAllAsync();
            var existe = usuarios.Any(u => u.Email.ToLower() == email.ToLower());
            return Json(!existe);
        }
        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "Debe ingresar un correo electrónico.";
                return View();
            }

            var usuario = (await _usuarioService.GetAllAsync()).FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
            if (usuario == null)
            {
                ViewBag.Error = "No se encontró un usuario con ese correo.";
                return View();
            }

            // Mostrar contraseña directamente (temporal / de prueba)
            ViewBag.Mensaje = $"La contraseña para {usuario.Email} es: {usuario.Password}";
            return View();
        }


    }
}
