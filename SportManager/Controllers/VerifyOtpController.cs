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
    public class VerifyOtpController : Controller
    {
        private readonly SportDbContext _context;

        public VerifyOtpController(SportDbContext context)
        {
            _context = context;
        }
        // GET: VerifyOtpController
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

        // POST: VerifyOtpController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginModel collection)
        {
            try
            {
                if (collection != null)
                {
                    Staff staff = _context.Staffs.Where(s => s.Email.Equals(collection.Username.Trim())).SingleOrDefault();
                    if (staff == null)
                    {
                        staff = _context.Staffs.Where(s => s.Phone.Equals(collection.Username.Trim())).SingleOrDefault();
                    }
                    if (staff != null)
                    {
                        if (staff.Otp.Equals((collection.Password.Trim())))
                        {
                            TimeSpan span = DateTime.Now.Subtract(staff.OtpDate);
                            if (span.Minutes < 60)
                            {
                                TempData["Success"] = "Success!"; 
                                staff.ChangePassword = true;
                                await _context.SaveChangesAsync();
                                return RedirectToAction("Index", "ForgotChangePassword");
                                
                            }
                            TempData["Failed"] = "Invalid OTP!";
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            TempData["Failed"] = "Invalid OTP!";
                            return RedirectToAction("Index", "Login");
                        }
                    }

                    if (staff == null)
                    {
                        Student student = _context.Students.Where(s => s.Email.Equals(collection.Username.Trim())).SingleOrDefault();
                        if (student == null)
                        {
                            student = _context.Students.Where(s => s.Phone.Equals(collection.Username.Trim())).SingleOrDefault();
                        }
                        if (student != null)
                        {
                            if (student.Otp.Equals((collection.Password.Trim())))
                            {

                                TimeSpan span = DateTime.Now.Subtract(staff.OtpDate);
                                if (span.Minutes < 60)
                                {
                                    TempData["Success"] = "Success!";
                                    student.ChangePassword = true;
                                    await _context.SaveChangesAsync();
                                    return RedirectToAction("Index", "ForgotChangePassword");

                                }
                                TempData["Failed"] = "Invalid OTP!";
                                return RedirectToAction("Index", "Login");
                            }
                            else
                            {
                                TempData["Failed"] = "Invalid OTP!";
                                return RedirectToAction("Index", "Login");
                            }
                        }
                        else
                        {
                            TempData["Failed"] = "Invalid OTP!";
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }
                TempData["Failed"] = "Invalid OTP!";
                return RedirectToAction("Index", "Login");
            }
            catch
            {
                TempData["Failed"] = "An error occured!";
                return RedirectToAction("Index", "Login");
            }
        }
    }
}
