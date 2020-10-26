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
    public class ForgotpasswordController : Controller
    {
        private readonly SportDbContext _context;

        public ForgotpasswordController(SportDbContext context)
        {
            _context = context;
        }
        // GET: ForgorpasswordController
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

        

        // POST: ForgorpasswordController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoginModel collection)
        {
            try
            {
                string RandomString = AppUtility.RandomString();
                Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                Parameter otpParameter = _context.Parameters.Where(p => p.Name.Equals("OTP_EXPIRY_IN_MINUTES")).SingleOrDefault();
                if (collection != null)
                {
                    Staff staff = _context.Staffs.Where(s => s.Email.Equals(collection.Username.Trim())).SingleOrDefault();
                    if (staff == null)
                    {
                        staff = _context.Staffs.Where(s => s.Phone.Equals(collection.Username.Trim())).SingleOrDefault();
                    }
                    if (staff != null)
                    {
                        staff.Otp = RandomString;
                        staff.OtpDate = DateTime.Now;

                        Message message = new Message
                        {
                            RecepientAddress=staff.Email,
                            RecepientName=staff.Firstname+" "+staff.Lastname,
                            MessageSubject="Forgot password - One Time Password",
                            MessageText="Dear "+staff.Firstname + " " + staff.Lastname+", \n"+
                            "Your OTP code is: "+RandomString+ ". \nKindly enter this to proceed. This code expires in " + otpParameter.Value + " minutes.",
                            MessageType="EMAIL",
                            MessageDate=DateTime.Now,
                            Sent=true
                        };

                        try
                        {
                            Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                        }
                        catch (Exception ex) { }
                        _context.Messages.Add(message);
                        await _context.SaveChangesAsync();
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
                            student.Otp = RandomString;
                            student.OtpDate = DateTime.Now;

                            Message message = new Message
                            {
                                RecepientAddress = student.Email,
                                RecepientName = student.Firstname + " " + student.Lastname,
                                MessageSubject = "Forgot password - One Time Password",
                                MessageText = "Dear " + student.Firstname + " " + student.Lastname + ", \n" +
                                "Your OTP code is: " + RandomString + ". Kindly enter this to proceed. This code expires in " + otpParameter.Value + " minutes.",
                                MessageType = "EMAIL",
                                MessageDate = DateTime.Now,
                                Sent = true
                            };

                            try
                            {
                                Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                            }
                            catch (Exception ex) { }

                            _context.Messages.Add(message);
                            await _context.SaveChangesAsync();

                            TempData["Success"] = "Kindly check your e-mail for the OTP code!";
                            return RedirectToAction(nameof(Index), "VerifyOtp");
                        }
                        else
                        {
                            TempData["Success"] = "Kindly check your e-mail for the OTP code!";
                            return RedirectToAction(nameof(Index), "VerifyOtp");
                        }
                    }
                }
                TempData["Success"] = "Kindly check your e-mail for the OTP code!";
                return RedirectToAction(nameof(Index), "VerifyOtp");
            }
            catch
            {
                TempData["Failed"] = "An error occured!";
                return RedirectToAction("Index", "Login");
            }
        }

    }
}
