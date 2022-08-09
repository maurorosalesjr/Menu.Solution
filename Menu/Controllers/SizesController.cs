using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Menu.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace Menu.Controllers
{
  public class SizesController : Controller
  {
    private readonly MenuContext _db;

    public SizesController(MenuContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Size> model = _db.Sizes.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Size Size)
    {
      _db.Sizes.Add(Size);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisSize = _db.Sizes
        .Include(Size => Size.JoinEntities)
        .ThenInclude(join => join.MenuItem)
        .FirstOrDefault(Size => Size.SizeId == id);
      return View(thisSize);
    }
    public ActionResult Edit(int id)
    {
      var thisSize = _db.Sizes.FirstOrDefault(Size => Size.SizeId == id);
      return View(thisSize);
    }

    [HttpPost]
    public ActionResult Edit(Size Size)
    {
      _db.Entry(Size).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisSize = _db.Sizes.FirstOrDefault(Size => Size.SizeId == id);
      return View(thisSize);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisSize = _db.Sizes.FirstOrDefault(Size => Size.SizeId == id);
      _db.Sizes.Remove(thisSize);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}
