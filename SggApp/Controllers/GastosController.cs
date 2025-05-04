using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class GastosController : Controller
{
    private static List<GastoViewModel> _gastos = new(); // Simula una BD en memoria

    public IActionResult Index()
    {
        return View(_gastos);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(GastoViewModel model)
    {
        if (ModelState.IsValid)
        {
            model.Id = _gastos.Count + 1;
            _gastos.Add(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult Edit(int id)
    {
        var gasto = _gastos.FirstOrDefault(g => g.Id == id);
        if (gasto == null) return NotFound();
        return View(gasto);
    }

    [HttpPost]
    public IActionResult Edit(int id, GastoViewModel model)
    {
        var gasto = _gastos.FirstOrDefault(g => g.Id == id);
        if (gasto == null) return NotFound();

        if (ModelState.IsValid)
        {
            gasto.Descripcion = model.Descripcion;
            gasto.Monto = model.Monto;
            gasto.Fecha = model.Fecha;
            gasto.CategoriaId = model.CategoriaId;
            return RedirectToAction("Index");
        }
        return View(model);
    }

    public IActionResult Details(int id)
    {
        var gasto = _gastos.FirstOrDefault(g => g.Id == id);
        if (gasto == null) return NotFound();
        return View(gasto);
    }

    public IActionResult Delete(int id)
    {
        var gasto = _gastos.FirstOrDefault(g => g.Id == id);
        if (gasto == null) return NotFound();
        return View(gasto);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var gasto = _gastos.FirstOrDefault(g => g.Id == id);
        if (gasto != null)
        {
            _gastos.Remove(gasto);
        }
        return RedirectToAction("Index");
    }
}
