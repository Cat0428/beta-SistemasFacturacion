using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SggApp.ViewModels;

namespace SggApp.Controllers
{
     [Authorize]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var usuarios = await _service.GetAllAsync();
            var viewModels = usuarios.Select(u => new UsuarioViewModel
            {
                Id = u.UsuarioId,
                Nombre = u.Nombre,
                Email = u.Email,
                Password = u.Password
            }).ToList();

            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var viewModel = new UsuarioViewModel
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
       public async Task<IActionResult> Create(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    Nombre = viewModel.Nombre,
                    Email = viewModel.Email,
                    Password = viewModel.Password
                };

                try
                {
                    await _service.CreateAsync(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch (InvalidOperationException ex)
                {
                    ModelState.AddModelError("Email", ex.Message);
                }
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var viewModel = new UsuarioViewModel
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UsuarioViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = new Usuario
                {
                    UsuarioId = viewModel.Id,
                    Nombre = viewModel.Nombre,
                    Email = viewModel.Email,
                    Password = viewModel.Password
                };

                await _service.UpdateAsync(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var usuario = await _service.GetByIdAsync(id);
            if (usuario == null) return NotFound();

            var viewModel = new UsuarioViewModel
            {
                Id = usuario.UsuarioId,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Password = usuario.Password
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<JsonResult> VerificarEmail(string email)
        {
            var usuarios = await _service.GetAllAsync();
            var existe = usuarios.Any(u => u.Email.ToLower() == email.ToLower());
            return Json(!existe); // true si está disponible, false si ya existe
        }

        [AcceptVerbs("GET", "POST")]
        public async Task<IActionResult> IsEmailAvailable(string email, int id)
        {
            var usuarios = await _service.GetAllAsync();
            var existe = usuarios.Any(u => u.Email.ToLower() == email.ToLower() && u.UsuarioId != id);
            return Json(!existe);
        }


    }
}
