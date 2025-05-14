using SistemaFactura.DAL.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SggApp.ViewModels;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.BLL.Services;
using System.Security.Claims;

namespace SggApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsuarioService _usuarioService;
        private readonly EmailService _emailService;

        public AuthController(IUsuarioService usuarioService, EmailService emailService)
        {
            _usuarioService = usuarioService;
            _emailService = emailService;
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
                ModelState.AddModelError("", ex.Message);
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

            // ✅ Cargar plantilla HTML
            var templatePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "PasswordRecoveryTemplate.html");
            string templateHtml = await System.IO.File.ReadAllTextAsync(templatePath);

            // ✅ Reemplazar marcadores
            string cuerpo = templateHtml
                .Replace("{{NOMBRE}}", usuario.Nombre)
                .Replace("{{PASSWORD}}", usuario.Password);

            // ✅ Enviar correo
            await _emailService.EnviarCorreoAsync(
                usuario.Email,
                "Recuperación de contraseña - FinApp",
                cuerpo
            );

            ViewBag.Mensaje = "La contraseña ha sido enviada a tu correo.";
            return View();
        }
    }
}
