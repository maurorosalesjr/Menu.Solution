using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Menu.Models;
using System.Collections.Generic;
using System.Linq;

namespace Menu.Controllers
{
  public class MenuItemsController : Controller
  {
    private readonly MenuContext _db;

    public MenuItemsController(MenuContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View(_db.MenuItems.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.SizeId = new SelectList(_db.Sizes, "SizeId", "SizeName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(MenuItem MenuItem, int SizeId)
    {
        _db.MenuItems.Add(MenuItem);
        _db.SaveChanges();
        if (SizeId != 0)
        {
            _db.MenuItemSize.Add(new MenuItemSize() { SizeId = SizeId, MenuItemId = MenuItem.MenuItemId });
            _db.SaveChanges();
        }
        return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      var thisMenuItem = _db.MenuItems
        .Include(MenuItem => MenuItem.JoinEntities)
        .ThenInclude(join => join.Size)
        .FirstOrDefault(MenuItem => MenuItem.MenuItemId == id);
      return View(thisMenuItem);
    }

    public ActionResult Edit(int id)
    {
      var thisMenuItem = _db.MenuItems.FirstOrDefault(MenuItem => MenuItem.MenuItemId == id);
      ViewBag.SizeId = new SelectList(_db.Sizes, "SizeId", "SizeName");
      return View(thisMenuItem);
    }

    [HttpPost]
    public ActionResult Edit(MenuItem MenuItem, int SizeId)
    {
      if (SizeId != 0)
      {
        _db.MenuItemSize.Add(new MenuItemSize() { SizeId = SizeId, MenuItemId = MenuItem.MenuItemId });
      }
      _db.Entry(MenuItem).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddOrder(int id)
    {
      var thisMenuItem = _db.MenuItems.FirstOrDefault(MenuItem => MenuItem.MenuItemId == id);
      ViewBag.SizeId = new SelectList(_db.Sizes, "SizeId", "SizeName");
      return View(thisMenuItem);
    }

    [HttpPost]
    public ActionResult AddOrder(MenuItem MenuItem, int SizeId)
    {
      if (SizeId != 0)
      {
        _db.MenuItemSize.Add(new MenuItemSize() { SizeId = SizeId, MenuItemId = MenuItem.MenuItemId });
        _db.SaveChanges();
      }
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      var thisMenuItem = _db.MenuItems.FirstOrDefault(MenuItem => MenuItem.MenuItemId == id);
      return View(thisMenuItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisMenuItem = _db.MenuItems.FirstOrDefault(MenuItem => MenuItem.MenuItemId == id);
      _db.MenuItems.Remove(thisMenuItem);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteSize(int joinId)
    {
      var joinEntry = _db.MenuItemSize.FirstOrDefault(entry => entry.MenuItemSizeId == joinId);
      _db.MenuItemSize.Remove(joinEntry);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}