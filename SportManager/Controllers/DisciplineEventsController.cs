using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;

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
    public class DisciplineEventsController : Controller
    {
        private readonly SportDbContext _context;

        public DisciplineEventsController(SportDbContext context)
        {
            _context = context;
        }
        // GET: DisciplineEventsController
        public async Task<ActionResult> Index(int id)
        {
            Staff staff = null;
            try
            {
                staff = SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff != null)
                {
                    staff = _context.Staffs.Include("SportDiscipinePatron").Where(s => s.Id.Equals(staff.Id)).SingleOrDefault();
                    try
                    {
                        Profile profile = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault();
                        if (profile.Name.Equals("Coordinator") || profile.Name.Equals("Secretary"))
                            ViewBag.CanAddEvent = true;
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
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = eventTypes;

                List<Event> events = _context.Events.Include("SportDisciplinesInEvent").ToList();
                List<Event> events_ = new List<Event>();
                foreach (Event _event in events)
                {
                    foreach(SportDisciplinesInEvent inEvent in _event.SportDisciplinesInEvent)
                    {
                        if (inEvent.SportDiscipineId.Equals(staff.SportDiscipinePatron.SportDiscipineId))
                            events_.Add(_event);
                    }
                    
                }
                if (id != null)
                {
                    if (id == 1)
                    {
                        events_ = events_.Where(e => e.PostPoned).ToList();
                    }
                    else if (id == 2)
                    {
                        events_ = events_.Where(e => e.Cancelled).ToList();
                    }
                }
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", events_);
                }
                catch (Exception ex) { }
                return View(events_);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: DisciplineEventsController/Details/5
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

        // GET: DisciplineEventsController/Create
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
            return View();
        }

        // POST: DisciplineEventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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

        // GET: DisciplineEventsController/Edit/5
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

        // POST: DisciplineEventsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: DisciplineEventsController/Delete/5
        public async Task<ActionResult> Delete(int id)
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

        // POST: DisciplineEventsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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
                        Style normal = new Style();
                        PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
                        normal.SetFont(font).SetFontSize(11);
                        String line = "REPORT";
                        document.Add(new Paragraph(line));

                        try
                        {
                            List<Event> students = SessionHelper.GetObjectFromJson<List<Event>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Event name", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Start date", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("End date", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Event type", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("No. of disciplines", (float)0.5, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach (Event student in students)
                                    {
                                        table.AddCell(createCell(student.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.StartDate.ToString(), (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.EndDate.ToString(), (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.EventType.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        //table.AddCell(createCell(student.SportDiscipine.Name, 1, 1, TextAlignment.LEFT));
                                        try
                                        {
                                            table.AddCell(createCell(Convert.ToString(student.SportDisciplinesInEvent.Count()), (float)0.5, 1, TextAlignment.LEFT));
                                        }
                                        catch (Exception ex)
                                        {
                                            table.AddCell(createCell("0", (float)0.5, 1, TextAlignment.LEFT));
                                        }
                                        //table.AddCell(createCell(student.Phone, 1, 1, TextAlignment.LEFT));
                                        //table.AddCell(createCell(student.SportDiscipine.Name, 1, 1, TextAlignment.LEFT));
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
