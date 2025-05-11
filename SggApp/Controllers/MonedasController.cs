using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;
using SggApp.ViewModels;


namespace SggApp.Controllers
{
     [Authorize]
    public class MonedasController : Controller
    {
        private readonly IMonedaService _service;

        public MonedasController(IMonedaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var items = await _service.GetAllAsync();
            var viewModels = items.Select(m => new MonedaViewModel
            {
                Id = m.MonedaId,
                Nombre = m.Nombre,
                Simbolo = m.Simbolo
            });

            return View(viewModels);
        }

        public async Task<IActionResult> Details(int id)
        {
            var m = await _service.GetByIdAsync(id);
            if (m == null) return NotFound();

            var viewModel = new MonedaViewModel
            {
                Id = m.MonedaId,
                Nombre = m.Nombre,
                Simbolo = m.Simbolo
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MonedaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entidad = new Moneda
                {
                    Nombre = viewModel.Nombre,
                    Simbolo = viewModel.Simbolo
                };

                await _service.CreateAsync(entidad);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var m = await _service.GetByIdAsync(id);
            if (m == null) return NotFound();

            var viewModel = new MonedaViewModel
            {
                Id = m.MonedaId,
                Nombre = m.Nombre,
                Simbolo = m.Simbolo
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MonedaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var entidad = new Moneda
                {
                    MonedaId = viewModel.Id,
                    Nombre = viewModel.Nombre,
                    Simbolo = viewModel.Simbolo
                };

                await _service.UpdateAsync(entidad);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var m = await _service.GetByIdAsync(id);
            if (m == null) return NotFound();

            var viewModel = new MonedaViewModel
            {
                Id = m.MonedaId,
                Nombre = m.Nombre,
                Simbolo = m.Simbolo
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
