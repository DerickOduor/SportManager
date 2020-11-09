using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportManager.Models;
using SportManager.Models.Context;

namespace SportManager.Controllers
{
    public class MenuController : Controller
    {
        private readonly SportDbContext _context;

        public MenuController(SportDbContext context)
        {
            _context = context;
        }
        // GET: MenuController
        public async Task<ActionResult> Index()
        {
            try
            {
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }

                List<Menu> menus = _context.Menus.Where(m => m.MenuType.Equals("MAINMENU")).ToList();

                return View(menus);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: MenuController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }
            }
            catch (Exception ex) { }
            try
            {
                Menu menu = _context.Menus.Where(m => m.Id.Equals(id)).SingleOrDefault();
                ViewBag.SubMenus = _context.Menus.Where(s => s.ParentId.Equals(menu.Id) & s.Id != menu.Id).ToList();

                return View(menu);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: MenuController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: MenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Menu collection)
        {
            try
            {
                Menu menu = _context.Menus.Where(m => m.Name.Equals(collection.Name) & m.MenuUser.Equals(collection.MenuUser)).SingleOrDefault();
                if (menu != null)
                {
                    ViewBag.Failed = "Menu with same name already exists!";
                    return View();
                }

                collection.Id = Guid.Empty;
                collection.Link = "#" + collection.Name;
                collection.MenuType = "MAINMENU";

                _context.Menus.Add(collection);
                await _context.SaveChangesAsync();

                try
                {
                    collection.ParentId = collection.Id;
                    _context.Menus.Update(collection);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex) { }

                ViewBag.Success = "Menu added successfully!";
                TempData["Success"] = "Menu added successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: MenuController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }
            }
            catch (Exception ex) { }
            try
            {
                Menu menu = _context.Menus.Where(m => m.Id.Equals(id)).SingleOrDefault();
                ViewBag.SubMenus = _context.Menus.Where(s => s.ParentId.Equals(menu.Id) & s.Id != menu.Id).ToList();

                return View(menu);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: MenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Menu collection)
        {
            try
            {

            }
            catch (Exception ex) { }
            try
            {
                Menu menu = _context.Menus.Where(m => m.Name.Equals(collection.Name) & m.MenuUser.Equals(collection.MenuUser)).SingleOrDefault();
                if (menu != null)
                {
                    if (!menu.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "Menu with same name already exists!";
                        return View();
                    }
                }
                collection.MenuType = "MAINMENU";
                _context.Menus.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Menu updated successfully!";
                TempData["Success"] = "Menu updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: MenuController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }
            }
            catch (Exception ex) { }
            try
            {
                Menu menu = _context.Menus.Where(m => m.Id.Equals(id)).SingleOrDefault();
                ViewBag.SubMenus = _context.Menus.Where(s => s.ParentId.Equals(menu.Id) & s.Id != menu.Id).ToList();

                return View(menu);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: MenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Menu collection)
        {
            try
            {
                Menu menu = _context.Menus.Where(m => m.Id.Equals(collection.Id)).SingleOrDefault();
                if (menu != null)
                {
                    _context.Menus.RemoveRange(_context.Menus.Where(m => m.ParentId.Equals(menu.Id) & !m.Id.Equals(menu.ParentId)).ToList());
                    _context.Menus.Remove(menu);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Menu deleted successfully!";
                TempData["Success"] = "Menu deleted successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }
    }
}
