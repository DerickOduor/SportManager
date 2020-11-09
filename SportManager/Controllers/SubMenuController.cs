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
    public class SubMenuController : Controller
    {
        private readonly SportDbContext _context;

        public SubMenuController(SportDbContext context)
        {
            _context = context;
        }
        // GET: SubMenuController
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
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: SubMenuController/Details/5
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
                ViewBag.Menu = _context.Menus.Where(m => m.Id.Equals(menu.ParentId)).SingleOrDefault();
                return View(menu);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: SubMenuController/Create
        public async Task<ActionResult> Create(Guid id)
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
                ViewBag.Menu = _context.Menus.Where(m => m.Id.Equals(id)).SingleOrDefault();
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SubMenuController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Menu collection)
        {
            try
            {
                Menu menu = _context.Menus.Where(m => m.Link.Equals(collection.Link) & m.MenuUser.Equals(collection.MenuUser)).SingleOrDefault();
                if (menu != null)
                {
                    ViewBag.Failed = "Menu with same link already exists!";
                    return View();
                }

                Menu parentMenu = _context.Menus.Where(m => m.Id.Equals(collection.ParentId)).SingleOrDefault();

                collection.Id = Guid.Empty;
                collection.MenuType = "SUB-MENU";
                collection.MenuUser = parentMenu.MenuUser;

                _context.Menus.Add(collection);
                await _context.SaveChangesAsync();

                try
                {
                    //collection.ParentId = collection.P;
                    //_context.Menus.Update(collection);
                    //await _context.SaveChangesAsync();
                }
                catch (Exception ex) { }

                ViewBag.Success = "Sub-menu added successfully!";
                TempData["Success"] = "Sub-menu added successfully!";

                return RedirectToAction(nameof(Details),"Menu",new { id=collection.ParentId});
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: SubMenuController/Edit/5
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
                ViewBag.Menu = _context.Menus.Where(m => m.Id.Equals(menu.ParentId)).SingleOrDefault();
                return View(menu);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SubMenuController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Menu collection)
        {
            try
            {
                Menu menu = _context.Menus.Where(m => m.Link.Equals(collection.Link) & m.MenuUser.Equals(collection.MenuUser)).SingleOrDefault();
                if (menu != null)
                {
                    if (!menu.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "Menu with same name already exists!";
                        return View();
                    }
                }

                _context.Menus.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Sub-menu updated successfully!";
                TempData["Success"] = "Sub-menu updated successfully!";

                return RedirectToAction(nameof(Details), "Menu", new { id = collection.ParentId });
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: SubMenuController/Delete/5
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
                ViewBag.Menu = _context.Menus.Where(m => m.Id.Equals(menu.ParentId)).SingleOrDefault();

                return View(menu);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SubMenuController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Menu collection)
        {
            try
            {
                Guid pare_id = collection.ParentId;
                Menu menu = _context.Menus.Where(m => m.Id.Equals(collection.Id)).SingleOrDefault();
                if (menu != null)
                {
                    _context.Menus.Remove(menu);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Sub-menu deleted successfully!";
                TempData["Success"] = "Sub-menu deleted successfully!";

                return RedirectToAction(nameof(Details), "Menu", new { id = pare_id });
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }
    }
}
