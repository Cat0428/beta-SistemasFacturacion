using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

public class CategoriasController : Controller
{
    private static List<CategoriaViewModel> _data = new();

    public IActionResult Index() => View(_data);
    public IActionResult Create() => View();

    [HttpPost]
    public IActionResult Create(CategoriaViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        model.Id = _data.Count + 1;
        _data.Add(model);
        return RedirectToAction("Index");
    }

    public IActionResult Edit(int id)
    {
        var item = _data.FirstOrDefault(x => x.Id == id);
        return item == null ? NotFound() : View(item);
    }

    [HttpPost]
    public IActionResult Edit(int id, CategoriaViewModel model)
    {
        var item = _data.FirstOrDefault(x => x.Id == id);
        if (item == null) return NotFound();
        if (!ModelState.IsValid) return View(model);
item.Nombre = model.Nombre;
        return RedirectToAction("Index");
    }

    public IActionResult Details(int id)
    {
        var item = _data.FirstOrDefault(x => x.Id == id);
        return item == null ? NotFound() : View(item);
    }

    public IActionResult Delete(int id)
    {
        var item = _data.FirstOrDefault(x => x.Id == id);
        return item == null ? NotFound() : View(item);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var item = _data.FirstOrDefault(x => x.Id == id);
        if (item != null) _data.Remove(item);
        return RedirectToAction("Index");
    }
}
