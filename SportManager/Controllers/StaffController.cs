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

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;
using iText.Kernel.Font;
using iText.IO.Font;

namespace SportManager.Controllers
{
    public class StaffController : Controller
    {
        private readonly SportDbContext _context;

        public StaffController(SportDbContext context)
        {
            _context = context;
        }

        // GET: StaffController
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
            try
            {
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                List<Staff> staffs = _context.Staffs.ToList().OrderBy(s => s.DateRegistered).ToList();
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", staffs);
                }
                catch (Exception ex) { }
                List<Profile> profiles = new List<Profile>();
                profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                ViewBag.profiles = new SelectList(profiles, "Id", "Name");

                
                return View(staffs);
            }
            catch(Exception ex) { }
            return View();
        }

        // GET: StaffController/Details/5
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
                List<Profile> profiles = new List<Profile>();
                profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                ViewBag.profiles = new SelectList(profiles, "Id", "Name");

                Staff staff =await _context.Staffs.Where(s=>s.Id.Equals(id)).SingleOrDefaultAsync();
                ViewBag.ProfileName = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault().Name;
                return View(staff);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: StaffController/Create
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
            try
            {
                List<Profile> profiles = new List<Profile>();
                profiles = _context.Profiles.Where(p=>p.Name!= "Student").ToList();
                ViewBag.profiles = new SelectList(profiles, "Id", "Name");
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Staff collection)
        {
            try
            {
                try
                {
                    List<Profile> profiles = new List<Profile>();
                    profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                    ViewBag.profiles = new SelectList(profiles, "Id", "Name");
                }
                catch (Exception ex) { }

                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (collection != null)
                {
                    if (collection.ProfileId == null)
                    {
                        ViewBag.Failed = "Select a profile";
                        return View();
                    }

                    string RandomString = AppUtility.RandomString();
                    Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                    Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                    Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                    Parameter otpParameter = _context.Parameters.Where(p => p.Name.Equals("OTP_EXPIRY_IN_MINUTES")).SingleOrDefault();

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
                    collection.Password = AppUtility.Encrypt(RandomString);
                    collection.RegistrationVerified = false;
                    collection.ChangePassword = true;
                    collection.Deleted = false;
                    collection.Status = false;
                    collection.Authorized = false;
                    Message message = new Message
                    {
                        RecepientAddress = collection.Email,
                        RecepientName = collection.Firstname + " " + collection.Lastname,
                        MessageSubject = "Account Creation",
                        MessageText = "Dear " + collection.Firstname + " " + collection.Lastname + ", \n" +
                                "Your account has been created with the SPORTS DEPARTMENT.\n" +
                                "Your password is: " + RandomString + ". \n" +
                                "Kindly enter this to activate your account. \n",
                        MessageType = "EMAIL",
                        MessageDate = DateTime.Now,
                        Sent = true
                    };
                    try
                    {
                        Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                    }
                    catch (Exception ex) { }

                    _context.Staffs.Add(collection);
                    _context.Messages.Add(message);

                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Staff created successfully!";
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StaffController/Edit/5
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
                List<Profile> profiles = new List<Profile>();
                profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                ViewBag.profiles = new SelectList(profiles, "Id", "Name");

                Staff staff =await _context.Staffs.Where(s => s.Id.Equals(id)).SingleOrDefaultAsync();
                return View(staff);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Staff collection)
        {
            try
            {
                try
                {
                    List<Profile> profiles = new List<Profile>();
                    profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                    ViewBag.profiles = new SelectList(profiles, "Id", "Name");
                }
                catch (Exception ex) { }

                if (!ModelState.IsValid)
                {
                    return View();
                }

                if (collection != null)
                {
                    if (collection.ProfileId == null)
                    {
                        ViewBag.Failed = "Select a profile";
                        return View();
                    }

                    string RandomString = AppUtility.RandomString();
                    Parameter emailFromParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILFROM")).SingleOrDefault();
                    Parameter emailFromAddressParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILADDRESS")).SingleOrDefault();
                    Parameter emailFromPasswordParameter = _context.Parameters.Where(p => p.Name.Equals("EMAILPASSWORD")).SingleOrDefault();
                    Parameter otpParameter = _context.Parameters.Where(p => p.Name.Equals("OTP_EXPIRY_IN_MINUTES")).SingleOrDefault();

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
                        if(!staff.Id.Equals(collection.Id))
                        {
                            ViewBag.Failed = "User with similar e-mail already exists!";
                            //return RedirectToAction(nameof(Index));
                            return View();
                        }
                    }

                    staff = await _context.Staffs.Where(s => s.Phone.Equals(collection.Phone.ToLower().Trim())).SingleOrDefaultAsync();
                    if (staff != null)
                    {
                        if (!staff.Id.Equals(collection.Id))
                        {
                            ViewBag.Failed = "User with similar phone number already exists!";
                            //return RedirectToAction(nameof(Index));
                            return View();
                        }
                    }

                    staff = await _context.Staffs.Where(s => s.RegistrationNumber.Equals(collection.RegistrationNumber.ToLower().Trim())).SingleOrDefaultAsync();
                    if (staff != null)
                    {
                        if (!staff.Id.Equals(collection.Id))
                        {
                            ViewBag.Failed = "User with similar registration number already exists!";
                            //return RedirectToAction(nameof(Index));
                            return View();
                        }
                    }

                    collection.Email = collection.Email.ToLower().Trim();
                    //collection.Otp = RandomString;
                    //collection.OtpDate = DateTime.Now;
                    //collection.Password = AppUtility.Encrypt(RandomString);
                    //if (collection.ChangePassword)
                    //{
                    //    Message message = new Message
                    //    {
                    //        RecepientAddress = collection.Email,
                    //        RecepientName = collection.Firstname + " " + collection.Lastname,
                    //        MessageSubject = "Change Password",
                    //        MessageText = "Dear " + collection.Firstname + " " + collection.Lastname + ", \n" +
                    //            "Your account has been created with the SPORTS DEPARTMENT.\n" +
                    //            "Your password is: " + RandomString + ". \n" +
                    //            "Kindly enter this to activate your account. \n",
                    //        MessageType = "EMAIL",
                    //        MessageDate = DateTime.Now,
                    //        Sent = true
                    //    };
                    //    try
                    //    {
                    //        Mail.SendMail(new List<Message> { message }, emailFromParameter.Value, emailFromAddressParameter.Value, AppUtility.Decrypt(emailFromPasswordParameter.Value));
                    //    }
                    //    catch (Exception ex) { }
                    //}
                    //_context.Messages.Add(message);
                    collection.Id = Guid.Empty;
                    collection.DateRegistered = DateTime.Now;
                    _context.Staffs.Add(collection);

                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Staff edited successfully!";
                }
                ViewBag.Success = "Staff edit failed!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Success = "An error occured!";
                return View();
            }
        }

        // GET: StaffController/Delete/5
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
                List<Profile> profiles = new List<Profile>();
                profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                ViewBag.profiles = new SelectList(profiles, "Id", "Name");

                Staff staff = await _context.Staffs.Where(s => s.Id.Equals(id)).SingleOrDefaultAsync();
                ViewBag.ProfileName = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault().Name;
                return View(staff);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Staff collection)
        {
            try
            {
                List<Profile> profiles = new List<Profile>();
                profiles = _context.Profiles.Where(p => p.Name != "Student").ToList();
                ViewBag.profiles = new SelectList(profiles, "Id", "Name");

                Staff staff = _context.Staffs.Where(s => s.Id.Equals(collection.Id)).SingleOrDefault();
                ViewBag.ProfileName = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault().Name;
                if (staff != null)
                {
                    staff.Deleted = true;

                    await _context.SaveChangesAsync();
                }
                TempData["Success"] = "Staff deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }
        public async Task<ActionResult> Report()
        {

            byte[] pdfBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfDocument pdf = new PdfDocument(new PdfWriter(stream)))
                {
                    using (iText.Layout.Document document = new iText.Layout.Document(pdf))
                    {
                        Style normal = new Style();
                        PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
                        normal.SetFont(font).SetFontSize(11);
                        String line = "REPORT";
                        document.Add(new Paragraph(line));

                        try
                        {
                            List<Staff> students = SessionHelper.GetObjectFromJson<List<Staff>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Name", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Staff no.", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Email", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Phone", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Profile", (float)0.5, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach (Staff student in students)
                                    {
                                        table.AddCell(createCell(student.Firstname+" "+student.Lastname, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.RegistrationNumber, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Email, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Phone, (float)0.5, 1, TextAlignment.LEFT));
                                        try
                                        {
                                            table.AddCell(createCell(student.Profile.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        }catch(Exception ex)
                                        {
                                            table.AddCell(createCell("N/A", (float)0.5, 1, TextAlignment.LEFT));
                                        }
                                    }

                                    table.AddStyle(normal);
                                    table.UseAllAvailableWidth();
                                    document.Add(table);
                                }
                            }
                        }
                        catch (Exception ex) { }

                        document.SetTextAlignment(TextAlignment.CENTER);
                        document.Close();
                        pdfBytes = stream.ToArray();
                        //return File(stream, "application/pdf");
                        return new FileContentResult(pdfBytes, "application/pdf");
                    }
                }
            }
        }

        public Cell createCell(String content, float borderWidth, int colspan, TextAlignment alignment)
        {
            Cell cell = new Cell(1, colspan).Add(new Paragraph(content));
            cell.SetTextAlignment(alignment);
            cell.SetBorder(new SolidBorder(borderWidth));

            cell.SetPadding(5);return cell;
        }
    }
}
