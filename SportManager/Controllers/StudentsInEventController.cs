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

using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using System.IO;

namespace SportManager.Controllers
{
    public class StudentsInEventController : Controller
    {
        private readonly SportDbContext _context;

        public StudentsInEventController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StudentsInEventController
        public async Task<ActionResult> Index(Guid id)
        {
            Staff staff = null;
            try
            {
                staff = SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff != null)
                {
                    try
                    {
                        Profile profile = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault();
                        if (/*staff.Profile*/profile.Name.Equals("Patron"))
                            ViewBag.CanAddStudent = true;
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }
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

                if (id.Equals(Guid.Empty))
                    return RedirectToAction("Index", "Event");

                List<StudentsParticipatingInEvent> students = _context.StudentsParticipatingInEvents
                    .Include("Student").Include("SportDisciplinesInEvent").Include("SportDisciplinesInEvent.Event")
                    .Include("SportDisciplinesInEvent.SportDiscipine")
                    .Where(s => s.SportDisciplinesInEventId.Equals(id)).ToList();
                ViewBag.Id = id;
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", students);
                }
                catch (Exception ex) { }
                return View(students);

            }
            catch (Exception ex) { }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(int id)
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
                if (id == 0)
                {

                }
                else if (id == 1)
                {

                }
                else if (id == 2)
                {

                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentsInEventController/Details/5
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

        // GET: StudentsInEventController/Create
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
                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Include("Event")
                    .Include("SportDiscipine").Where(s => s.Id.Equals(id)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
                List<Student> students = _context.Students.Include("SportDiscipine")
                    .Where(s => s.SportDiscipineId.Equals(disciplineInEvent.SportDiscipineId)).ToList();
                ViewBag.Students = new SelectList(students, "Id", "RegistrationNumber");
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StudentsInEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentsParticipatingInEvent collection)
        {
            try
            {
                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Include("Event")
                    .Include("SportDiscipine").Where(s => s.Id.Equals(collection.SportDisciplinesInEventId)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
                List<Student> students = _context.Students.Include("SportDiscipine")
                    .Where(s => s.SportDiscipineId.Equals(disciplineInEvent.SportDiscipineId)).ToList();
                ViewBag.Students = new SelectList(students, "Id", "RegistrationNumber");
            }
            catch (Exception ex) { }
            try
            {
                StudentsParticipatingInEvent participatingInEvent = _context.StudentsParticipatingInEvents.Where(s => s.StudentId.Equals(collection.StudentId)
                      & s.SportDisciplinesInEventId.Equals(collection.SportDisciplinesInEventId)).SingleOrDefault();

                if (participatingInEvent != null)
                {
                    ViewBag.Failed = "Student already added to event!";
                    return View();
                }

                collection.Id = Guid.Empty;

                _context.StudentsParticipatingInEvents.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Student added to event successfully!";
                TempData["Success"] = "Student added to event successfully!";

                return RedirectToAction(nameof(Index),new { id= collection.SportDisciplinesInEventId });
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
                return View();
            }
        }

        // GET: StudentsInEventController/Edit/5
        public async Task<ActionResult> Edit(int id)
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

        // POST: StudentsInEventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentsInEventController/Delete/5
        public async Task<ActionResult> Delete(Guid id,Guid studentid)
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
                StudentsParticipatingInEvent participatingInEvent = _context.StudentsParticipatingInEvents.Where(s => s.StudentId.Equals(studentid)
                      & s.SportDisciplinesInEventId.Equals(id)).SingleOrDefault();

                if (participatingInEvent != null)
                {
                    _context.StudentsParticipatingInEvents.Remove(participatingInEvent);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Student removed from event successfully!";
                TempData["Success"] = "Student removed from event successfully!";
            }
            catch (Exception ex) 
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
            }
            Guid k_id = id;
            return RedirectToAction(nameof(Index), new { id= k_id });
        }

        // POST: StudentsInEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
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
                        String line = "REPORT";
                        document.Add(new Paragraph(line));

                        try
                        {
                            List<StudentsParticipatingInEvent> students = SessionHelper.GetObjectFromJson<List<StudentsParticipatingInEvent>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Name", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Reg. No.", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Discipine", 1, 1, TextAlignment.LEFT));

                                    foreach (StudentsParticipatingInEvent student in students)
                                    {
                                        table.AddCell(createCell(student.Student.Firstname+" "+student.Student.Lastname, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Student.RegistrationNumber, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.SportDisciplinesInEvent.SportDiscipine.Name, 1, 1, TextAlignment.LEFT));
                                    }
                                }
                            }
                        }
                        catch (Exception ex) { }

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

            return cell;
        }
    }
}
