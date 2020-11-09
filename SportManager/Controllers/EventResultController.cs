﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;

namespace SportManager.Controllers
{
    public class EventResultController : Controller
    {
        private readonly SportDbContext _context;

        public EventResultController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventResultController
        /// <summary>
        /// SportDisciplinesInEvent
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
                        if (profile.Name.Equals("Coordinator") || profile.Name.Equals("Secretary"))
                            ViewBag.CanAddResult = true;
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
                List<EventResult> results = _context.EventResults.Include("SportDisciplinesInEvent")
                    .Include("TournamentStage").Include("SportDisciplinesInEvent.SportDiscipine")
                    .Where(r=>r.SportDisciplinesInEventId.Equals(id)).ToList();

                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents
                    .Include("SportDiscipine").Where(s => s.Id.Equals(id)).SingleOrDefault();

                ViewBag.SportDisciplineInEvent = disciplineInEvent;

                return View(results);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventResultController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                EventResult result = _context.EventResults.Include("SportDisciplinesInEvent").Include("SportDisciplinesInEvent.Event")
                    .Include("SportDisciplinesInEvent.SportDiscipine")
                    .Include("TournamentStage").Where(r => r.SportDisciplinesInEventId.Equals(id))
                    .SingleOrDefault();

                return View(result);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventResultController/Create
        public async Task<ActionResult> Create(Guid id)
        {
            try
            {
                List<TournamentStage> tournamentStages = _context.TournamentStages.ToList();
                ViewBag.TournamentStages = new SelectList(tournamentStages,"Id","Name");

                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Where(s => s.Id.Equals(id)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventResultController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventResult collection)
        {
            try
            {
                List<TournamentStage> tournamentStages = _context.TournamentStages.ToList();
                ViewBag.TournamentStages = new SelectList(tournamentStages, "Id", "Name");

                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Where(s => s.Id.Equals(collection.SportDisciplinesInEventId)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
            }
            catch (Exception ex) { }
            try
            {
                collection.Id = Guid.Empty;

                _context.EventResults.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Result added successfully!";
                TempData["Success"] = "Result added successfully!";

                return RedirectToAction(nameof(Index),new { id=collection.SportDisciplinesInEventId});
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventResultController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                List<TournamentStage> tournamentStages = _context.TournamentStages.ToList();
                ViewBag.TournamentStages = new SelectList(tournamentStages, "Id", "Name");
            }
            catch (Exception ex) { }
            try
            {
                EventResult result = _context.EventResults.Include("SportDisciplinesInEvent").Include("SportDisciplinesInEvent.SportDiscipine")
                    .Include("TournamentStage").Where(r => r.SportDisciplinesInEventId.Equals(id))
                    .SingleOrDefault();

                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Where(s => s.Id.Equals(result.SportDisciplinesInEventId)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;

                return View(result);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventResultController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, EventResult collection)
        {
            try
            {
                List<TournamentStage> tournamentStages = _context.TournamentStages.ToList();
                ViewBag.TournamentStages = new SelectList(tournamentStages, "Id", "Name");

                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Where(s => s.Id.Equals(collection.SportDisciplinesInEventId)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
            }
            catch (Exception ex) { }
            try
            {
                _context.EventResults.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Result updated successfully!";
                TempData["Success"] = "Result updated successfully!";

                return RedirectToAction(nameof(Index), new { id = collection.SportDisciplinesInEventId });
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventResultController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                EventResult result = _context.EventResults.Include("SportDisciplinesInEvent").Include("SportDisciplinesInEvent.SportDiscipine")
                    .Include("TournamentStage").Where(r => r.SportDisciplinesInEventId.Equals(id))
                    .SingleOrDefault();

                return View(result);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventResultController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, EventResult collection)
        {
            try
            {
                EventResult result = _context.EventResults.Where(e => e.Id.Equals(collection.Id)).SingleOrDefault();
                if (result != null)
                {
                    _context.EventResults.Remove(result);
                    await _context.SaveChangesAsync();
                }
                ViewBag.Success = "Result deleted successfully!";
                TempData["Success"] = "Result deleted successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        public async Task<ActionResult> P_D_F() 
        {
            //byte[] pdfBytes;
            //using (var stream = new MemoryStream())
            //using (var wri = new PdfWriter(stream))
            //using (var pdf = new PdfDocument(wri))
            //using (var doc = new Document(pdf))
            //{
            //    doc.Add(new Paragraph("Hello World!"));
            //    doc.Flush();
            //    pdfBytes = stream.ToArray();
            //}
            //return new FileContentResult(pdfBytes, "application/pdf");

            byte[] pdfBytes;
            using (MemoryStream stream = new MemoryStream())
            {
                using (PdfDocument pdf = new PdfDocument(new PdfWriter(stream)))
                {
                    using (Document document = new Document(pdf))
                    {
                        String line = "Hello! Welcome to iTextPdf";
                        document.Add(new Paragraph(line));
                        document.Close();
                        pdfBytes = stream.ToArray();
                        //return File(stream, "application/pdf");
                        return new FileContentResult(pdfBytes, "application/pdf");
                    }
                }
            }

            //byte[] pdfBytes;
            //MemoryStream stream = new MemoryStream();
            ////using (/*var stream = new MemoryStream()*/stream)
            //using (var wri = new PdfWriter(stream))
            //using (var pdf = new PdfDocument(wri))
            //using (var doc = new Document(pdf))
            //{
            //    doc.Add(new Paragraph("Hello World!"));
            //    doc.Flush();
            //    pdfBytes = stream.ToArray();
            //}
            //return File(stream, "application/pdf");


            //MemoryStream stream = new MemoryStream();
            //PdfWriter pdfWriter = new PdfWriter(stream);

            //PdfDocument pdf = new PdfDocument(pdfWriter);
            //Document document = new Document(pdf);
            //document.Add(new Paragraph("Hello World"));
            //document.Close();

            ////stream.Flush(); //Always catches me out
            ////stream.Position = 0; //Not sure if this is required

            //return File(stream, "application/pdf", "HelloWorld.pdf");
        }
    }
}