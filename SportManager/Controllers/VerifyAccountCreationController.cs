using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportManager.Models;
using SportManager.Models.Context;
using SportManager.Models.Utils;

namespace SportManager.Controllers
{
    public class VerifyAccountCreationController : Controller
    {
        private readonly SportDbContext _context;

        public VerifyAccountCreationController(SportDbContext context)
        {
            _context = context;
        }
        // GET: VerifyAccountCreationController
        public async Task<ActionResult> Index(string id)
        {
            try
            {
                if (id != null)
                {
                    //if(id.Equals())
                }
                if (HttpContext.Session.GetString("VERIFY_USER") == null)
                {
                    return RedirectToAction(nameof(Index),"Login");
                }
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: VerifyAccountCreationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginModel collection)
        {
            try
            {
                if (collection != null)
                {
                    if (HttpContext.Session.GetString("VERIFY_USER") != null)
                    {
                        string RandomString = AppUtility.RandomString();
                        Models.Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                        Models.Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                        Models.Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                        Models.Parameter otpParameter = _context.Parameters.Where(p => p.Name.Equals("OTP_EXPIRY_IN_MINUTES")).SingleOrDefault();
                        Models.Staff staff = _context.Staffs.Where(s => s.Email.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                        if (staff == null)
                        {
                            staff = _context.Staffs.Where(s => s.Phone.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                        }
                        if (staff != null)
                        {
                            staff.RegistrationVerified = true;

                            await _context.SaveChangesAsync();

                            TempData["Success"] = "Account verified successfully!";
                            HttpContext.Session.Remove("VERIFY_USER");
                            return RedirectToAction(nameof(Index),"Login");
                        }

                        if (staff == null)
                        {
                            Models.Student student = _context.Students.Where(s => s.Email.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                            if (student == null)
                            {
                                student = _context.Students.Where(s => s.Phone.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                            }
                            if (student != null)
                            {
                                student.RegistrationVerified = true;
                                
                                await _context.SaveChangesAsync();

                                TempData["Success"] = "Account verified successfully!";
                                HttpContext.Session.Remove("VERIFY_USER");
                                return RedirectToAction(nameof(Index), "Login");
                            }
                            else
                            {
                                TempData["Success"] = "Could not verify your account! Kindly click Resend Otp.";
                                return RedirectToAction(nameof(Index));
                            }
                        }
                    }
                }
                //HttpContext.Session.SetString("VERIFY_USER", collection.Email);
                TempData["Success"] = "Could not verify your account! Kindly click Resend Otp.";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["Success"] = "An error occured!";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<ActionResult> ResendOtp()
        {
            try
            {
                if (HttpContext.Session.GetString("VERIFY_USER") != null)
                {
                    string RandomString = AppUtility.RandomString();
                    Models.Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                    Models.Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                    Models.Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                    Models.Parameter otpParameter = _context.Parameters.Where(p => p.Name.Equals("OTP_EXPIRY_IN_MINUTES")).SingleOrDefault();
                    Models.Staff staff = _context.Staffs.Where(s => s.Email.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                    if (staff == null)
                    {
                        staff = _context.Staffs.Where(s => s.Phone.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                    }
                    if (staff != null)
                    {
                        staff.Otp = RandomString;
                        staff.OtpDate = DateTime.Now;

                        Models.Message message = new Models.Message
                        {
                            RecepientAddress = staff.Email,
                            RecepientName = staff.Firstname + " " + staff.Lastname,
                            MessageSubject = "Verify Account Creation - One Time Password",
                            MessageText = "Dear " + staff.Firstname + " " + staff.Lastname + ", \n" +
                            "Your OTP code is: " + RandomString + ". \nKindly enter this to proceed. This code expires in " + otpParameter.Value + " minutes.",
                            MessageType = "EMAIL",
                            MessageDate = DateTime.Now,
                            Sent = true
                        };

                        try
                        {
                            Mail.SendMail(new List<Models.Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                        }
                        catch (Exception ex) { }
                        _context.Messages.Add(message);
                        await _context.SaveChangesAsync();

                        TempData["Success"] = "Kindly check your e-mail for the OTP code!";
                        return RedirectToAction(nameof(Index));
                    }

                    if (staff == null)
                    {
                        Models.Student student = _context.Students.Where(s => s.Email.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                        if (student == null)
                        {
                            student = _context.Students.Where(s => s.Phone.Equals(HttpContext.Session.GetString("VERIFY_USER"))).SingleOrDefault();
                        }
                        if (student != null)
                        {
                            student.Otp = RandomString;
                            student.OtpDate = DateTime.Now;

                            Models.Message message = new Models.Message
                            {
                                RecepientAddress = student.Email,
                                RecepientName = student.Firstname + " " + student.Lastname,
                                MessageSubject = "Verify Account Creation - One Time Password",
                                MessageText = "Dear " + student.Firstname + " " + student.Lastname + ", \n" +
                                "Your OTP code is: " + RandomString + ". Kindly enter this to proceed. This code expires in " + otpParameter.Value + " minutes.",
                                MessageType = "EMAIL",
                                MessageDate = DateTime.Now,
                                Sent = true
                            };

                            try
                            {
                                Mail.SendMail(new List<Models.Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                            }
                            catch (Exception ex) { }

                            _context.Messages.Add(message);
                            await _context.SaveChangesAsync();

                            TempData["Success"] = "Kindly check your e-mail for the OTP code!";
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            TempData["Success"] = "Kindly check your e-mail for the OTP code!";
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
            }
            catch (Exception ex) { }
            return RedirectToAction(nameof(Index));
        }
    }
}
