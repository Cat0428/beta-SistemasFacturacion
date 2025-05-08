using Microsoft.AspNetCore.Mvc;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SggApp.ViewModels;

namespace SggApp.Controllers
{
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
                Email = u.Correo,
                Password = u.Clave
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
                Email = usuario.Correo,
                Password = usuario.Clave
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
                    Correo = viewModel.Email,
                    Clave = viewModel.Password
                };

                await _service.CreateAsync(usuario);
                return RedirectToAction(nameof(Index));
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
                Email = usuario.Correo,
                Password = usuario.Clave
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
                    Correo = viewModel.Email,
                    Clave = viewModel.Password
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
                Email = usuario.Correo,
                Password = usuario.Clave
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
