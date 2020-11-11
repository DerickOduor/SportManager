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

namespace SportManager.Controllers
{
    public class VenueController : Controller
    {
        private readonly SportDbContext _context;

        public VenueController(SportDbContext context)
        {
            _context = context;
        }
        // GET: VenueController
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
                List<Venue> venues = _context.Venues.ToList();
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", venues);
                }
                catch (Exception ex) { }
                return View(venues);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: VenueController/Details/5
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
                Venue venue =await  _context.Venues.Where(v=>v.Id.Equals(id)).SingleOrDefaultAsync();
                return View(venue);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: VenueController/Create
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

        // POST: VenueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Venue collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Venue venue =await _context.Venues.Where(v => v.Name.Equals(collection.Name)).SingleOrDefaultAsync();
                if (venue != null)
                {
                    ViewBag.Failed = "A venue with a same name exists!";
                    return View();
                }
                _context.Venues.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Venue added successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: VenueController/Edit/5
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
                Venue venue = await _context.Venues.Where(v => v.Id.Equals(id)).SingleOrDefaultAsync();
                return View(venue);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: VenueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Venue collection)
        {
            try
            {
                if (collection != null)
                {
                    Venue venue =await _context.Venues.Where(v => v.Name.Equals(collection.Name)).SingleOrDefaultAsync();
                    if (venue != null)
                    {
                        if (!venue.Id.Equals(collection.Id))
                        {
                            ViewBag.Failed = "A venue with a same name exists!";
                            return View();
                        }
                    }

                    _context.Venues.Update(collection);
                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Venue updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Failed = "Venue update failed!";
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: VenueController/Delete/5
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
                Venue venue = await _context.Venues.Where(v => v.Id.Equals(id)).SingleOrDefaultAsync();
                return View(venue);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: VenueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Venue collection)
        {
            try
            {
                Venue venue =await _context.Venues.Where(v => v.Id.Equals(collection.Id)).SingleOrDefaultAsync();
                if (venue != null)
                {
                    _context.Venues.Remove(venue);
                    await _context.SaveChangesAsync();
                    ViewBag.Success = "Venue deleted successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Failed = "Venue deletion failed!";
                return View();
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
                        String line = "REPORT";
                        document.Add(new Paragraph(line));

                        try
                        {
                            List<Venue> students = SessionHelper.GetObjectFromJson<List<Venue>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Name", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Location", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Capacity", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Available", 1, 1, TextAlignment.LEFT));

                                    foreach (Venue student in students)
                                    {
                                        table.AddCell(createCell(student.Name, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Location, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Capacity+"", 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Available?"Yes":"No", 1, 1, TextAlignment.LEFT));
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
