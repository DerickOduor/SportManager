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
using SportManager.Models.Utils;

namespace SportManager.Controllers
{
    public class StudentRegistrationController : Controller
    {
        private readonly SportDbContext _context;

        public StudentRegistrationController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StudentRegistrationController
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
                List<SportDiscipine> sportDiscipines = new List<SportDiscipine>();
                sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.sportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction(nameof(Create));
            return View();
        }

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
                List<SportDiscipine> sportDiscipines = new List<SportDiscipine>();
                sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.sportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: StudentRegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Student collection)
        {
            try
            {
                List<SportDiscipine> sportDiscipines = new List<SportDiscipine>();
                sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.sportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
                string RandomString = AppUtility.RandomString();
                Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                Parameter otpParameter = _context.Parameters.Where(p => p.Name.Equals("OTP_EXPIRY_IN_MINUTES")).SingleOrDefault();
                if (!ModelState.IsValid)
                {
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                if (collection == null)
                {
                    ViewBag.Failed = "Registration failed!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                if (!collection.Password.Trim().Equals(collection.ConfirmPassword.Trim()))
                {
                    ViewBag.Failed = "Passwords do not match!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                Student student = await _context.Students.Where(s => s.Email.Equals(collection.Email.ToLower().Trim())).SingleOrDefaultAsync();
                if (student != null)
                {
                    ViewBag.Failed = "User with similar e-mail already exists!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                student = await _context.Students.Where(s => s.Phone.Equals(collection.Phone.ToLower().Trim())).SingleOrDefaultAsync();
                if (student != null)
                {
                    ViewBag.Failed = "User with similar phone number already exists!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                student = await _context.Students.Where(s => s.RegistrationNumber.Equals(collection.RegistrationNumber.ToLower().Trim())).SingleOrDefaultAsync();
                if (student != null)
                {
                    ViewBag.Failed = "User with similar registration number already exists!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }
                Staff staff = await _context.Staffs.Where(s => s.Email.Equals(collection.Email.ToLower().Trim())).SingleOrDefaultAsync();
                if (staff != null)
                {
                    ViewBag.Failed = "User with similar e-mail already exists!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                staff = await _context.Staffs.Where(s => s.Phone.Equals(collection.Phone.ToLower().Trim())).SingleOrDefaultAsync();
                if (staff != null)
                {
                    ViewBag.Failed = "User with similar phone number already exists!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                staff = await _context.Staffs.Where(s => s.RegistrationNumber.Equals(collection.RegistrationNumber.ToLower().Trim())).SingleOrDefaultAsync();
                if (staff != null)
                {
                    ViewBag.Failed = "User with similar registration number already exists!";
                    //return RedirectToAction(nameof(Index));
                    return View();
                }

                collection.Email = collection.Email.ToLower().Trim();
                collection.Otp = RandomString;
                collection.OtpDate = DateTime.Now;
                collection.Password = AppUtility.Encrypt(collection.Password);
                collection.RegistrationVerified = false;
                collection.ProfileId =_context.Profiles.Where(p => p.Name.Equals("Student")).SingleOrDefault().Id;
                Message message = new Message
                {
                    RecepientAddress = collection.Email,
                    RecepientName = collection.Firstname + " " + collection.Lastname,
                    MessageSubject = "Student Registration",
                    MessageText = "Dear " + collection.Firstname + " " + collection.Lastname + ", \n" +
                            "Your OTP code is: " + RandomString + ". \nKindly enter this to activate your account. \n" +
                            "This code expires in "+ otpParameter .Value+ " minutes.",
                    MessageType = "EMAIL",
                    MessageDate = DateTime.Now,
                    Sent = true
                };
                try
                {
                    Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                }
                catch (Exception ex) { }

                _context.Students.Add(collection);
                _context.Messages.Add(message);

                await _context.SaveChangesAsync();
                HttpContext.Session.SetString("VERIFY_USER",collection.Email);
                return RedirectToAction(nameof(Index), "VerifyAccountCreation", new { id = nameof(Student) });
            }
            catch
            {
                //return RedirectToAction(nameof(Index));
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }
    }
}
