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
using iText.Kernel.Font;
using iText.IO.Font;

namespace SportManager.Controllers
{
    public class EventSessionController : Controller
    {
        private readonly SportDbContext _context;

        public EventSessionController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventSessionController
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
                            ViewBag.CanAddSession = true;
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return RedirectToAction("Index","Event");
                }
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<EventSession> eventSessions = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.EventId.Equals(id)).ToList();
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", eventSessions);
                }
                catch (Exception ex) { }
                return View(eventSessions);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventSessionController/Details/5
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
                EventSession eventSession = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.Id.Equals(id)).SingleOrDefault();
                return View(eventSession);
            }catch(Exception ex)
            {
                
            }
            return View();
        }

        // GET: EventSessionController/Create
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
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<Venue> venues= _context.Venues.ToList();
                ViewBag.Venues = new SelectList(venues, "Id", "Name");
            }
            catch(Exception ex)
            {
                
            }
            return View();
        }

        // POST: EventSessionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventSession collection)
        {
            try
            {
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(collection.EventId)).SingleOrDefault();
                List<Venue> venues = _context.Venues.ToList();
                ViewBag.Venues = new SelectList(venues, "Id", "Name");
                if (!ModelState.IsValid)
                {
                    return View();
                }
                EventSession eventSession = _context.EventSessions.Where(e => e.Name.Equals(collection.Name) & e.EventId.Equals(collection.EventId)).SingleOrDefault();
                if (eventSession != null)
                {
                    ViewBag.Failed="Session with the same name already exists!";
                    return View();
                }
                try
                {
                    List<EventSession> sessions = _context.EventSessions.Include("Event").ToList();
                    if (sessions != null)
                    {
                        foreach(EventSession session in sessions)
                        {
                            if(session.StartTime<collection.StartTime & session.EndTime > collection.EndTime)
                            {
                                if (session.VenueId.Equals(collection.VenueId))
                                {
                                    ViewBag.Failed = "Venue already booked for Session: "+session.Name+", Event:"+session.Event.Name;
                                    return View();
                                }
                            }
                        }
                    }
                }catch(Exception ex)
                {

                }
                collection.Id = Guid.Empty;
                _context.EventSessions.Add(collection);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Session added successfully";
                return RedirectToAction(nameof(Index),new { id= collection.EventId });
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventSessionController/Edit/5
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
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<Venue> venues = _context.Venues.ToList();
                ViewBag.Venues = new SelectList(venues, "Id", "Name");
                EventSession eventSession = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.Id.Equals(id)).SingleOrDefault();
                return View(eventSession);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: EventSessionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EventSession collection)
        {
            try
            {
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(collection.EventId)).SingleOrDefault();
                ViewBag.Venues = _context.Venues.ToList();
                if (!ModelState.IsValid)
                {
                    return View();
                }
                EventSession eventSession = _context.EventSessions.Where(e => e.Name.Equals(collection.Name) & e.EventId.Equals(collection.EventId)).SingleOrDefault();
                if (eventSession != null)
                {
                    if (eventSession.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "Session with the same name already exists!";
                        return View();
                    }
                }

                _context.EventSessions.Add(collection);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Session edited successfully";
                return RedirectToAction(nameof(Index),new { id = collection.EventId });
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventSessionController/Delete/5
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
                EventSession eventSession = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.Id.Equals(id)).SingleOrDefault();
                return View(eventSession);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: EventSessionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, EventSession collection)
        {
            Guid event_id=Guid.NewGuid();
            try
            {
                EventSession eventSession = _context.EventSessions.Where(e => e.Id.Equals(collection.Id)).SingleOrDefault();
                event_id = eventSession.EventId;
                _context.EventSessions.Remove(eventSession);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Session deleted successfully";
                return RedirectToAction(nameof(Index), new { id= event_id });
            }
            catch
            {
                ViewBag.Failed="An error occured!";
                //return View();
                return RedirectToAction(nameof(Delete), new { id = event_id });
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
                            List<EventSession> students = SessionHelper.GetObjectFromJson<List<EventSession>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Session name", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Event", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Start time", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("End time", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Venue", (float)0.5, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach (EventSession student in students)
                                    {
                                        table.AddCell(createCell(student.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Event.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.StartTime.ToString(), (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.EndTime.ToString(), (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Venue.Name, (float)0.5, 1, TextAlignment.LEFT));
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
