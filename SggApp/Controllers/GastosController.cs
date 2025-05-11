using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SggApp.ViewModels;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;

namespace SggApp.Controllers
{
     [Authorize]
    public class GastosController : Controller
    {
        private readonly IGastoService _gastoService;
        private readonly IUsuarioService _usuarioService;
        private readonly ICategoriaService _categoriaService;
        private readonly IMonedaService _monedaService;

        public GastosController(IGastoService gastoService, IUsuarioService usuarioService,
                                ICategoriaService categoriaService, IMonedaService monedaService)
        {
            _gastoService = gastoService;
            _usuarioService = usuarioService;
            _categoriaService = categoriaService;
            _monedaService = monedaService;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _gastoService.GetAllAsync();
            var viewModels = items.Select(item => new GastoViewModel
            {
                Id = item.GastoId,
                Descripcion = item.Descripcion,
                Fecha = item.Fecha,
                Monto = item.Monto,
                CategoriaNombre = item.Categoria?.Nombre ?? "",
                MonedaNombre = item.Moneda?.Nombre ?? "",
                UsuarioNombre = item.Usuario?.Nombre ?? ""
            });

            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var item = await _gastoService.GetByIdAsync(id);
            if (item == null) return NotFound();

            var viewModel = new GastoViewModel
            {
                Id = item.GastoId,
                Descripcion = item.Descripcion,
                Fecha = item.Fecha,
                Monto = item.Monto,
                CategoriaNombre = item.Categoria?.Nombre ?? "",
                MonedaNombre = item.Moneda?.Nombre ?? "",
                UsuarioNombre = item.Usuario?.Nombre ?? ""
            };

            return View(viewModel);
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new GastoViewModel
            {
                Usuarios = (await _usuarioService.GetAllAsync())
                    .Select(u => new SelectListItem { Value = u.UsuarioId.ToString(), Text = u.Nombre }),
                Categorias = (await _categoriaService.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.CategoriaId.ToString(), Text = c.Nombre }),
                Monedas = (await _monedaService.GetAllAsync())
                    .Select(m => new SelectListItem { Value = m.MonedaId.ToString(), Text = m.Nombre })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GastoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var gasto = new Gasto
                {
                    Descripcion = viewModel.Descripcion,
                    Fecha = viewModel.Fecha,
                    Monto = viewModel.Monto,
                    UsuarioId = viewModel.UsuarioId,
                    CategoriaId = viewModel.CategoriaId,
                    MonedaId = viewModel.MonedaId
                };

                await _gastoService.CreateAsync(gasto);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Usuarios = (await _usuarioService.GetAllAsync())
                .Select(u => new SelectListItem { Value = u.UsuarioId.ToString(), Text = u.Nombre });
            viewModel.Categorias = (await _categoriaService.GetAllAsync())
                .Select(c => new SelectListItem { Value = c.CategoriaId.ToString(), Text = c.Nombre });
            viewModel.Monedas = (await _monedaService.GetAllAsync())
                .Select(m => new SelectListItem { Value = m.MonedaId.ToString(), Text = m.Nombre });

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var item = await _gastoService.GetByIdAsync(id);
            if (item == null) return NotFound();

            var viewModel = new GastoViewModel
            {
                Id = item.GastoId,
                Descripcion = item.Descripcion,
                Fecha = item.Fecha,
                Monto = item.Monto,
                UsuarioId = item.UsuarioId,
                CategoriaId = item.CategoriaId,
                MonedaId = item.MonedaId,
                Usuarios = (await _usuarioService.GetAllAsync())
                    .Select(u => new SelectListItem { Value = u.UsuarioId.ToString(), Text = u.Nombre }),
                Categorias = (await _categoriaService.GetAllAsync())
                    .Select(c => new SelectListItem { Value = c.CategoriaId.ToString(), Text = c.Nombre }),
                Monedas = (await _monedaService.GetAllAsync())
                    .Select(m => new SelectListItem { Value = m.MonedaId.ToString(), Text = m.Nombre })
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GastoViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var gasto = new Gasto
                {
                    GastoId = viewModel.Id,
                    Descripcion = viewModel.Descripcion,
                    Fecha = viewModel.Fecha,
                    Monto = viewModel.Monto,
                    UsuarioId = viewModel.UsuarioId,
                    CategoriaId = viewModel.CategoriaId,
                    MonedaId = viewModel.MonedaId
                };

                await _gastoService.UpdateAsync(gasto);
                return RedirectToAction(nameof(Index));
            }

            viewModel.Usuarios = (await _usuarioService.GetAllAsync())
                .Select(u => new SelectListItem { Value = u.UsuarioId.ToString(), Text = u.Nombre });
            viewModel.Categorias = (await _categoriaService.GetAllAsync())
                .Select(c => new SelectListItem { Value = c.CategoriaId.ToString(), Text = c.Nombre });
            viewModel.Monedas = (await _monedaService.GetAllAsync())
                .Select(m => new SelectListItem { Value = m.MonedaId.ToString(), Text = m.Nombre });

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _gastoService.GetByIdAsync(id);
            if (item == null) return NotFound();

            var viewModel = new GastoViewModel
            {
                Id = item.GastoId,
                Descripcion = item.Descripcion,
                Fecha = item.Fecha,
                Monto = item.Monto,
                CategoriaNombre = item.Categoria?.Nombre ?? "",
                MonedaNombre = item.Moneda?.Nombre ?? "",
                UsuarioNombre = item.Usuario?.Nombre ?? ""
            };

            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _gastoService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
