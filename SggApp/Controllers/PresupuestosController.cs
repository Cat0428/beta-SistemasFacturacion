using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SggApp.ViewModels;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;

namespace SggApp.Controllers
{
    public class PresupuestosController : Controller
    {
        private readonly IPresupuestoService _presupuestoService;
        private readonly IUsuarioService _usuarioService;

        public PresupuestosController(IPresupuestoService presupuestoService, IUsuarioService usuarioService)
        {
            _presupuestoService = presupuestoService;
            _usuarioService = usuarioService;
        }

        // GET: Index
        public async Task<IActionResult> Index()
        {
            var items = await _presupuestoService.GetAllAsync();

            var viewModels = items.Select(p => new PresupuestoViewModel
            {
                Id = p.PresupuestoId,
                FechaInicio = p.FechaInicio,
                FechaFin = p.FechaFin,
                Monto = p.Monto,
                UsuarioId = p.UsuarioId,
                UsuarioNombre = p.Usuario?.Nombre ?? ""
            });

            return View(viewModels);
        }

        // GET: Details
        public async Task<IActionResult> Details(int id)
        {
            var item = await _presupuestoService.GetByIdAsync(id);
            if (item == null) return NotFound();

            var viewModel = new PresupuestoViewModel
            {
                Id = item.PresupuestoId,
                FechaInicio = item.FechaInicio,
                FechaFin = item.FechaFin,
                Monto = item.Monto,
                UsuarioId = item.UsuarioId,
                UsuarioNombre = item.Usuario?.Nombre ?? ""
            };

            return View(viewModel);
        }

        // GET: Create
        public async Task<IActionResult> Create()
        {
            var usuarios = await _usuarioService.GetAllAsync();

            var viewModel = new PresupuestoViewModel
            {
                Usuarios = usuarios.Select(u => new SelectListItem
                {
                    Value = u.UsuarioId.ToString(),
                    Text = u.Nombre
                })
            };

            return View(viewModel);
        }

        // POST: Create
        [HttpPost]
        public async Task<IActionResult> Create(PresupuestoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var usuarios = await _usuarioService.GetAllAsync();
                viewModel.Usuarios = usuarios.Select(u => new SelectListItem
                {
                    Value = u.UsuarioId.ToString(),
                    Text = u.Nombre
                });

                return View(viewModel);
            }

            var entity = new Presupuesto
            {
                FechaInicio = viewModel.FechaInicio,
                FechaFin = viewModel.FechaFin,
                Monto = viewModel.Monto,
                UsuarioId = viewModel.UsuarioId
            };

            await _presupuestoService.CreateAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        // GET: Edit
        public async Task<IActionResult> Edit(int id)
        {
            var item = await _presupuestoService.GetByIdAsync(id);
            if (item == null) return NotFound();

            var usuarios = await _usuarioService.GetAllAsync();

            var viewModel = new PresupuestoViewModel
            {
                Id = item.PresupuestoId,
                FechaInicio = item.FechaInicio,
                FechaFin = item.FechaFin,
                Monto = item.Monto,
                UsuarioId = item.UsuarioId,
                Usuarios = usuarios.Select(u => new SelectListItem
                {
                    Value = u.UsuarioId.ToString(),
                    Text = u.Nombre
                })
            };

            return View(viewModel);
        }

        // POST: Edit
        [HttpPost]
        public async Task<IActionResult> Edit(PresupuestoViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var usuarios = await _usuarioService.GetAllAsync();
                viewModel.Usuarios = usuarios.Select(u => new SelectListItem
                {
                    Value = u.UsuarioId.ToString(),
                    Text = u.Nombre
                });

                return View(viewModel);
            }

            var entity = new Presupuesto
            {
                PresupuestoId = viewModel.Id,
                FechaInicio = viewModel.FechaInicio,
                FechaFin = viewModel.FechaFin,
                Monto = viewModel.Monto,
                UsuarioId = viewModel.UsuarioId
            };

            await _presupuestoService.UpdateAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        // GET: Delete
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _presupuestoService.GetByIdAsync(id);
            if (item == null) return NotFound();

            var viewModel = new PresupuestoViewModel
            {
                Id = item.PresupuestoId,
                FechaInicio = item.FechaInicio,
                FechaFin = item.FechaFin,
                Monto = item.Monto,
                UsuarioNombre = item.Usuario?.Nombre ?? ""
            };

            return View(viewModel);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _presupuestoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
