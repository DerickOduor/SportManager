using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;

namespace SportManager.Controllers
{
    public class AccessRightsController : Controller
    {
        private readonly SportDbContext _context;

        public AccessRightsController(SportDbContext context)
        {
            _context = context;
        }
        // GET: AccessRightsController
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

        // GET: AccessRightsController/Details/5
        public async Task<ActionResult> Details(int id)
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

        // GET: AccessRightsController/Create
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
                List<Profile> profiles = _context.Profiles.Include("AccessRights").ToList();
                ViewBag.Profiles = new SelectList(profiles, "Id", "Name");

                List<Menu> menus = _context.Menus.ToList();
                if (!id.Equals(Guid.Empty))
                {
                    Profile profile = _context.Profiles.Include("AccessRights").Where(p => p.Id.Equals(id)).SingleOrDefault();
                    if (profile != null)
                    {
                        ViewBag.Profile = profile;
                        foreach (AccessRight accessRight in profile.AccessRights)
                        {
                            foreach (Menu menu in menus)
                            {
                                if (menu.Id.Equals(accessRight.MenuId))
                                {
                                    menu.Assigned = true;
                                }
                            }
                        }
                    }
                }

                ViewBag.Menus = menus;
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: AccessRightsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AccessRight collection, Guid ProfileId, Guid[] menuid)
        {
            try
            {
                List<Menu> menus = new List<Menu>();
                List<AccessRight> userRights = new List<AccessRight>();

                try
                {
                    menus = _context.Menus.ToList();//SessionHelper.GetObjectFromJson<List<Menu>>(HttpContext.Session, "Menus");
                    foreach (Menu menu in menus.Where(m => m.MenuType.ToUpper().Trim().Equals("MAINMENU")).ToList())
                    {
                        foreach (Guid m in menuid)
                        {
                            if (menu.Id == m)
                            {
                                userRights.Add(new AccessRight
                                {
                                    ProfileId = ProfileId,
                                    MenuId = menu.Id,
                                    ParentMenuId = menu.ParentId,
                                    Id=Guid.Empty
                                });
                            }
                        }
                    }

                    List<Menu> selected_Sub_menus = new List<Menu>();

                    foreach (Menu menu in menus.Where(m => m.MenuType.ToUpper().Trim().Equals("SUB-MENU")).ToList())
                    {
                        foreach (Guid m in menuid)
                        {
                            if (m == menu.Id)
                            {
                                selected_Sub_menus.Add(menu);
                                userRights.Add(new AccessRight
                                {
                                    ProfileId = ProfileId,
                                    MenuId = menu.Id,
                                    ParentMenuId = menu.ParentId,
                                    Id = Guid.Empty
                                });
                            }
                        }
                    }

                    if (userRights.Count > 0)
                    {
                        _context.AccessRights.RemoveRange(_context.AccessRights.Where(a=>a.ProfileId.Equals(ProfileId)).ToList());
                        _context.AccessRights.AddRange(userRights);
                        await _context.SaveChangesAsync();
                    }

                    ViewBag.Success = "Rights assigned success fully!";
                    TempData["Success"] = "Rights assigned success fully!";

                }
                catch (Exception ex)
                {
                    ViewBag.Failed = "An error occured!";
                    TempData["Failed"] = "An error occured!";
                }

                return RedirectToAction(nameof(Create),new { id=ProfileId});
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
                return View();
            }
        }

        // GET: AccessRightsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: AccessRightsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AccessRightsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: AccessRightsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
