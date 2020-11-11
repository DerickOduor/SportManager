using System;
using System.Collections.Generic;
using System.IO;
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

namespace SportManager.Controllers
{
    public class EventDisciplinesController : Controller
    {
        private readonly SportDbContext _context;

        public EventDisciplinesController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventDisciplinesController
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
                        if (/*staff.Profile*/profile.Name.Equals("Secretary") || /*staff.Profile*/profile.Name.Equals("Coordinator"))
                            ViewBag.CanAddDiscipline = true; ViewBag.CanAddStudent = true;
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
                {
                    return RedirectToAction("Index", "Event");
                }
                try
                {
                    ViewBag.Id = id;
                }
                catch (Exception ex)
                {

                }
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<SportDisciplinesInEvent> sportDisciplinesInEvent = _context.SportDisciplinesInEvents
                    .Include("Event").Include("SportDiscipine").Include("StudentsParticipatingInEvent").ToList();
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", sportDisciplinesInEvent);
                }
                catch (Exception ex) { }
                return View(sportDisciplinesInEvent);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventDisciplinesController/Details/5
        public ActionResult Details(Guid id)
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

        // GET: EventDisciplinesController/Create
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
                if (id.Equals(Guid.Empty))
                {
                    return RedirectToAction("Index", "Event");
                }

                Event _event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                ViewBag.Event = _event;
                List<SportDiscipine> sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.SportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventDisciplinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SportDisciplinesInEvent collection)
        {
            try
            {
                Event _event = _context.Events.Where(e => e.Id.Equals(collection.EventId)).SingleOrDefault();
                ViewBag.Event = _event;
                List<SportDiscipine> sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.SportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
            }
            catch (Exception ex) { }
            try
            {
                SportDisciplinesInEvent sportDisciplinesInEvent = _context.SportDisciplinesInEvents.Where(s => s.EventId.Equals(collection.EventId)
                      & s.SportDiscipineId.Equals(collection.SportDiscipineId)).SingleOrDefault();

                if (sportDisciplinesInEvent != null)
                {
                    ViewBag.Failed = "Discipline already exists in this event!";
                    return View();
                }
                collection.Id = Guid.Empty;
                _context.SportDisciplinesInEvents.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Discipline added successfully to event!";
                TempData["Success"] = "Discipline added successfully to event!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventDisciplinesController/Edit/5
        public ActionResult Edit(int id)
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

        // POST: EventDisciplinesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EventDisciplinesController/Delete/5
        public async Task<ActionResult> Delete(Guid id,Guid jd)
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
                SportDisciplinesInEvent sportDisciplinesInEvent = _context.SportDisciplinesInEvents.Where(s => s.Id.Equals(id)).SingleOrDefault();
                if (sportDisciplinesInEvent != null)
                {
                    _context.SportDisciplinesInEvents.Remove(sportDisciplinesInEvent);
                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Removed successfully!";
                    TempData["Success"] = "Removed successfully!";
                    return RedirectToAction("Index", jd);
                }
            }
            catch (Exception ex) { }
            ViewBag.Failed = "An error occured!";
            TempData["Failed"] = "An error occured!";
            return RedirectToAction("Index",new { id= jd });
        }

        // POST: EventDisciplinesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
                            List<SportDisciplinesInEvent> students = SessionHelper.GetObjectFromJson<List<SportDisciplinesInEvent>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Event name", 1, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("Name", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Sport discipline", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("No. of students", 1, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach (SportDisciplinesInEvent student in students)
                                    {
                                        table.AddCell(createCell(student.Event.Name, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.SportDiscipine.Name , 1, 1, TextAlignment.LEFT));
                                        try
                                        {
                                            table.AddCell(createCell(Convert.ToString(student.StudentsParticipatingInEvent.Count()), 1, 1, TextAlignment.LEFT));
                                        }catch(Exception ex)
                                        {
                                            table.AddCell(createCell("0", 1, 1, TextAlignment.LEFT));
                                        }
                                        //table.AddCell(createCell(student.Phone, 1, 1, TextAlignment.LEFT));
                                        //table.AddCell(createCell(student.SportDiscipine.Name, 1, 1, TextAlignment.LEFT));
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
