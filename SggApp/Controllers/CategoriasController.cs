using Microsoft.AspNetCore.Mvc;
using SggApp.ViewModels;
using SistemaFactura.BLL.Interfaces;
using SistemaFactura.DAL.Entities;

namespace SggApp.Controllers
{
    public class CategoriasController : Controller
    {
        private readonly ICategoriaService _service;

        public CategoriasController(ICategoriaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var categorias = await _service.GetAllAsync();
            var viewModelList = categorias.Select(c => new CategoriaViewModel
            {
                Id = c.CategoriaId,
                Nombre = c.Nombre
            });

            return View(viewModelList);
        }

        public async Task<IActionResult> Details(int id)
        {
            var c = await _service.GetByIdAsync(id);
            if (c == null) return NotFound();

            var viewModel = new CategoriaViewModel
            {
                Id = c.CategoriaId,
                Nombre = c.Nombre
            };

            return View(viewModel);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria
                {
                    Nombre = viewModel.Nombre
                };

                await _service.CreateAsync(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var c = await _service.GetByIdAsync(id);
            if (c == null) return NotFound();

            var viewModel = new CategoriaViewModel
            {
                Id = c.CategoriaId,
                Nombre = c.Nombre
            };

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoriaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var categoria = new Categoria
                {
                    CategoriaId = viewModel.Id,
                    Nombre = viewModel.Nombre
                };

                await _service.UpdateAsync(categoria);
                return RedirectToAction(nameof(Index));
            }

            return View(viewModel);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var c = await _service.GetByIdAsync(id);
            if (c == null) return NotFound();

            var viewModel = new CategoriaViewModel
            {
                Id = c.CategoriaId,
                Nombre = c.Nombre
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
