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
    public class ForgotChangePasswordController : Controller
    {
        private readonly SportDbContext _context;

        public ForgotChangePasswordController(SportDbContext context)
        {
            _context = context;
        }
        // GET: ForgotChangePasswordController
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

        // POST: ForgotChangePasswordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginModel collection)
        {
            try
            {
                if (!collection.Password.Equals(collection.ConfirmPassword))
                {
                    TempData["Failed"] = "These passwords do not match!";
                    ViewBag.Failed = "These passwords do not match!";
                    return RedirectToAction(nameof(Index));
                }
                Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                if (collection != null)
                {
                    Staff staff = _context.Staffs.Where(s => s.Email.Equals(collection.Username.Trim())).SingleOrDefault();
                    if (staff == null)
                    {
                        staff = _context.Staffs.Where(s => s.Phone.Equals(collection.Username.Trim())).SingleOrDefault();
                    }
                    if (staff != null)
                    {
                        if (staff.ChangePassword)
                        {
                            TempData["Success"] = "Change password success!";
                            staff.ChangePassword = false;
                            staff.Password = AppUtility.Encrypt(collection.Password);

                            Message message = new Message
                            {
                                RecepientAddress = staff.Email,
                                RecepientName = staff.Firstname + " " + staff.Lastname,
                                MessageSubject = "Password Change",
                                MessageText = "Dear " + staff.Firstname + " " + staff.Lastname + ", \n" +
                                "Your password was changed at: "+DateTime.UtcNow+". \n" +
                                "If this was not you kindly proceed to change your password.",
                                MessageType = "EMAIL",
                                MessageDate = DateTime.Now,
                                Sent = true
                            };
                            try
                            {
                                Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                            }
                            catch (Exception ex) { }

                            await _context.SaveChangesAsync();
                            return RedirectToAction("Index", "Login");
                        }
                        else
                        {
                            TempData["Failed"] = "Change password failed!";
                            return RedirectToAction(nameof(Index));
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
                            if (student.ChangePassword)
                            {
                                TempData["Success"] = "Change password success!";
                                student.ChangePassword = false;
                                student.Password = AppUtility.Encrypt(collection.Password);

                                Message message = new Message
                                {
                                    RecepientAddress = student.Email,
                                    RecepientName = student.Firstname + " " + student.Lastname,
                                    MessageSubject = "Password Change",
                                    MessageText = "Dear " + student.Firstname + " " + student.Lastname + ", \n" +
                                "Your password was changed at: " + DateTime.UtcNow + ". \n" +
                                "If this was not you kindly proceed to change your password.",
                                    MessageType = "EMAIL",
                                    MessageDate = DateTime.Now,
                                    Sent = true
                                };
                                try
                                {
                                    Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                                }
                                catch (Exception ex) { }

                                await _context.SaveChangesAsync();
                                return RedirectToAction("Index", "Login");
                            }
                            else
                            {
                                TempData["Failed"] = "Change password failed!";
                                return RedirectToAction("Index", "Login");
                            }
                        }
                        else
                        {
                            TempData["Failed"] = "Change password failed!";
                            return RedirectToAction("Index", "Login");
                        }
                    }
                }
                TempData["Failed"] = "Change password failed!";
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
