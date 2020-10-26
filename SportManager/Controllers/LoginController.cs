using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;
using SportManager.Models.Utils;

namespace SportManager.Controllers
{
    public class LoginController : Controller
    {
        private readonly SportDbContext _context;

        public LoginController(SportDbContext context)
        {
            _context = context;
        }
        // GET: LoginController
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

        // POST: LoginController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginModel collection)
        {
            try
            {
                List<Menu> menus = new List<Menu>();
                List<Menu> subMenus = new List<Menu>();
                List<AccessRight> accessRights = new List<AccessRight>();
                if (collection != null)
                {
                    Staff staff = _context.Staffs.Where(s => s.Email.Equals(collection.Username.Trim())).SingleOrDefault();
                    if (staff == null)
                    {
                        staff= _context.Staffs.Where(s => s.Phone.Equals(collection.Username.Trim())).SingleOrDefault();
                    }
                    if (staff != null)
                    {
                        if (staff.Password.Equals(AppUtility.Encrypt(collection.Password.Trim())))
                        {
                            if (!staff.RegistrationVerified || staff.ChangePassword)
                            {
                                HttpContext.Session.SetString("VERIFY_USER", staff.Email);
                                return RedirectToAction(nameof(Index), "VerifyAccountCreation", new { id = nameof(Staff) });
                            }
                            if (staff.Deleted)
                            {
                                TempData["Failed"] = "Login failed!";
                                return RedirectToAction(nameof(Index));
                            }
                            try
                            {
                                accessRights = _context.AccessRights.Include(nameof(Menu)).Where(a => a.ProfileId == staff.ProfileId).ToList();
                                foreach (AccessRight access in accessRights)
                                {
                                    if (access.Menu != null)
                                    {
                                        if (access.Menu.MenuType.Equals("MAINMENU"))
                                        {
                                            menus.Add(new Menu
                                            {
                                                Id = access.Menu.Id,
                                                Name = access.Menu.Name,
                                                Link = access.Menu.Link,
                                                MenuType = access.Menu.MenuType,
                                                MenuUser = access.Menu.MenuUser,
                                                ParentId=access.Menu.ParentId
                                            });
                                        }
                                        else if (access.Menu.MenuType.Equals("SUB-MENU"))
                                        {
                                            subMenus.Add(new Menu
                                            {
                                                Id = access.Menu.Id,
                                                Name = access.Menu.Name,
                                                Link = access.Menu.Link,
                                                MenuType = access.Menu.MenuType,
                                                MenuUser = access.Menu.MenuUser,
                                                ParentId = access.Menu.ParentId
                                            });
                                        }
                                    }
                                }
                            }
                            catch (Exception ex) { }
                            //TempData["Success"] = "Login success!";
                            SessionHelper.SetObjectAsJson(HttpContext.Session, "MY_l_USER", staff);
                            HttpContext.Session.SetString("USERTYPE", "STAFF");
                            try
                            {
                                SessionHelper.SetObjectAsJson(HttpContext.Session, "MY_P_MENUS", menus.OrderBy(m => m.Level));
                            }catch(Exception ex)
                            {

                            }
                            try
                            {
                                SessionHelper.SetObjectAsJson(HttpContext.Session, "MY_S_MENUS", subMenus.OrderBy(m => m.Level));
                            }catch(Exception ex)
                            {
                                
                            }
                            return RedirectToAction("Index","Home");
                        }
                        else
                        {
                            TempData["Failed"] = "Login failed!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                    
                    if (staff == null)
                    {
                        Student student=_context.Students.Where(s => s.Email.Equals(collection.Username.Trim())).SingleOrDefault();
                        if (student == null)
                        {
                            student = _context.Students.Where(s => s.Phone.Equals(collection.Username.Trim())).SingleOrDefault();
                        }
                        if (student != null)
                        {
                            if (student.Password.Equals(AppUtility.Encrypt(collection.Password.Trim())))
                            {
                                if (!student.RegistrationVerified || student.ChangePassword)
                                {
                                    HttpContext.Session.SetString("VERIFY_USER", student.Email);
                                    return RedirectToAction(nameof(Index), "VerifyAccountCreation", new { id = nameof(Staff) });
                                }
                                try
                                {
                                    accessRights = _context.AccessRights.Include(nameof(Menu)).Where(a => a.ProfileId == student.ProfileId).ToList();
                                    foreach (AccessRight access in accessRights)
                                    {
                                        if (access.Menu != null)
                                        {
                                            if (access.Menu.MenuType.Equals("MAINMENU"))
                                            {
                                                menus.Add(new Menu
                                                {
                                                    Id = access.Menu.Id,
                                                    Name = access.Menu.Name,
                                                    Link = access.Menu.Link,
                                                    MenuType = access.Menu.MenuType,
                                                    MenuUser = access.Menu.MenuUser
                                                });
                                            }
                                            else if (access.Menu.MenuType.Equals("SUB-MENU"))
                                            {
                                                subMenus.Add(new Menu
                                                {
                                                    Id = access.Menu.Id,
                                                    Name = access.Menu.Name,
                                                    Link = access.Menu.Link,
                                                    MenuType = access.Menu.MenuType,
                                                    MenuUser = access.Menu.MenuUser
                                                });
                                            }
                                        }
                                    }
                                }catch (Exception ex) { }
                                TempData["Success"] = "Login success!";
                                SessionHelper.SetObjectAsJson(HttpContext.Session, "MY_l_USER", student);
                                SessionHelper.SetObjectAsJson(HttpContext.Session, "MY_P_MENUS", menus);
                                SessionHelper.SetObjectAsJson(HttpContext.Session, "MY_S_MENUS", subMenus);
                                HttpContext.Session.SetString("USERTYPE", "STUDENT");
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                TempData["Failed"] = "Login failed!";
                                return RedirectToAction(nameof(Index));
                            }
                        }
                        else
                        {
                            TempData["Failed"] = "Login failed!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                TempData["Failed"] = "Login failed!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Failed"] = "An error occured!";
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
