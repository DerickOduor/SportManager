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
    public class SportController : Controller
    {
        private readonly SportDbContext _context;

        public SportController(SportDbContext context)
        {
            _context = context;
        }
        // GET: SportController
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

                List<SportDiscipine> sportDiscipines = _context.SportDiscipines.Include("SportDiscipinePatron")
                    .Include("Students").Include("Teams").Include("StoreItemsInUse").Include("SportDiscipinePatron.Staff").ToList();
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", sportDiscipines);
                }
                catch (Exception ex) { }

                return View(sportDiscipines);

            }catch(Exception ex) { }
            return View();
        }

        // GET: SportController/Details/5
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
                SportDiscipine discipine = _context.SportDiscipines.Include("SportDiscipinePatron")
                    .Include("Students").Include("Teams").Include("StoreItemsInUse").Include("SportDiscipinePatron.Staff").Where(s => s.Id.Equals(id)).SingleOrDefault();

                return View(discipine);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: SportController/Create
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

        // POST: SportController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SportDiscipine collection)
        {
            try
            {
                SportDiscipine discipine = _context.SportDiscipines.Where(s => s.Name.Equals(collection.Name)).SingleOrDefault();
                if (discipine != null) 
                {
                    ViewBag.Failed = "A discipline with the same name already exist!";
                    return View();
                }
                collection.DateAdded = DateTime.Now;
                _context.SportDiscipines.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Discipline added successfully!";
                TempData["Success"] = "Discipline added successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: SportController/Edit/5
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
                SportDiscipine discipine = _context.SportDiscipines.Include("SportDiscipinePatron")
                    .Include("Students").Include("Teams").Include("StoreItemsInUse").Include("SportDiscipinePatron.Staff").Where(s => s.Id.Equals(id)).SingleOrDefault();

                return View(discipine);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SportController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, SportDiscipine collection)
        {
            try
            {
                SportDiscipine discipine = _context.SportDiscipines.Where(s => s.Name.Equals(collection.Name) & !s.Id.Equals(collection.Id)).SingleOrDefault();
                if (discipine != null)
                {
                    ViewBag.Failed = "A discipline with the same name already exist!";
                    return View();
                }

                _context.SportDiscipines.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Discipline updated successfully!";
                TempData["Success"] = "Discipline updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: SportController/Delete/5
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
                SportDiscipine discipine = _context.SportDiscipines.Include("SportDiscipinePatron")
                    .Include("Students").Include("Teams").Include("StoreItemsInUse").Include("SportDiscipinePatron.Staff").Where(s => s.Id.Equals(id)).SingleOrDefault();

                return View(discipine);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SportController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, SportDiscipine collection)
        {
            try
            {
                SportDiscipine discipine = _context.SportDiscipines.Where(s => s.Name.Equals(collection.Name) & !s.Id.Equals(collection.Id)).SingleOrDefault();
                if (discipine != null)
                {
                    _context.SportDiscipines.Remove(collection);
                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Discipline deleted successfully!";
                    TempData["Success"] = "Discipline deleted successfully!";
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
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
                            List<SportDiscipine> students = SessionHelper.GetObjectFromJson<List<SportDiscipine>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Name", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Patron", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("No. of students", (float)0.5, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach (SportDiscipine student in students)
                                    {
                                        table.AddCell(createCell(student.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.SportDiscipinePatron.Staff.Firstname+" "+ student.SportDiscipinePatron.Staff.Lastname, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Students.Count()+"", (float)0.5, 1, TextAlignment.LEFT));
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
