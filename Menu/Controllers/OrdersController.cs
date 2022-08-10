using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Menu.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Menu.Controllers
{
  public class OrdersController : Controller
  {
    private readonly MenuContext _db;

    public OrdersController(MenuContext db) 
    {
      _db = db;
    }

    public ActionResult Index() 
    {
      return View(_db.Orders.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.SizeId = new SelectList(_db.Sizes, "SizeId", "SizeName");
      ViewBag.MenuItemId = new Select(_db.MenuItems, "MenuItemId", "Name");

      return View();
    }

    [HttpPost]
    public ActionResult Create(Order Order, int SizeId, string Name)
    {
    _db.Orders.Add(Order);
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
      var thisOrder = _db.Orders
        .Include(Order => Order.JoinEntities)
        .ThenInclude(join => join.MenuItem)
        .ThenInclude(join => join.Size)
        .FirstOrDefault(Order => Order.OrderId == id);
      return View(thisOrder);
    }
  }
}