using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportManager.Models;
using SportManager.Models.Context;
using SportManager.Models.Utils;

namespace SportManager.Controllers
{
    public class ChangePasswordController : Controller
    {

        private readonly SportDbContext _context;

        public ChangePasswordController(SportDbContext context)
        {
            _context = context;
        }
        // GET: ChangePasswordController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: ChangePasswordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginModel collection)
        {
            try
            {
                if (!collection.Password.Equals(collection.ConfirmPassword))
                {
                    ViewBag.Failed = "New and confirm passwords do not match!";
                    return View();
                }

                string UserType= HttpContext.Session.GetString("USERTYPE");
                if (UserType.ToUpper().Equals("STAFF"))
                {
                    Staff staff= SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                    string EncrPass = AppUtility.Encrypt(collection.CurrentPassword.Trim());
                    Staff in_db = _context.Staffs.Where(s => s.Email.Equals(staff.Email) & s.Password.Equals(EncrPass)).SingleOrDefault();

                    if (in_db == null)
                    {
                        ViewBag.Failed = "Invalid credentials!";
                        return View();
                    }
                    else
                    {
                        if (in_db.Password.Equals(EncrPass))
                        {
                            ViewBag.Failed = "Current and new password are the same! Use a different password.";
                            return View();
                        }
                        in_db.Password = AppUtility.Encrypt(collection.Password.Trim());

                        _context.Staffs.Update(in_db);
                        await _context.SaveChangesAsync();
                        ViewBag.Success = "Password changed successfully!";
                        TempData["Success"] = "Password changed successfully!";
                        return RedirectToAction("Index","Logout");
                    }
                }
                else if (UserType.ToUpper().Equals("STUDENT"))
                {
                    Student student = SessionHelper.GetObjectFromJson<Student>(HttpContext.Session, "MY_l_USER");
                    string EncrPass = AppUtility.Encrypt(collection.CurrentPassword.Trim());
                    Student in_db = _context.Students.Where(s => s.Email.Equals(student.Email) & s.Password.Equals(EncrPass)).SingleOrDefault();

                    if (in_db == null)
                    {
                        ViewBag.Failed = "Invalid credentials!";
                        return View();
                    }
                    else
                    {
                        if (in_db.Password.Equals(EncrPass))
                        {
                            ViewBag.Failed = "Current and new password are the same! Use a different password.";
                            return View();
                        }
                        in_db.Password = AppUtility.Encrypt(collection.Password.Trim());

                        _context.Students.Update(in_db);
                        await _context.SaveChangesAsync();
                        ViewBag.Success = "Password changed successfully!";
                        TempData["Success"] = "Password changed successfully!";
                        return RedirectToAction("Index", "Logout");
                    }
                }
                ViewBag.Failed = "An error occured!";
                return View();
                //return RedirectToAction(nameof(Create));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

    }
}
