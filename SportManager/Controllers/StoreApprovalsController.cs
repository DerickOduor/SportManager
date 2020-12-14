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
    public class StoreApprovalsController : Controller
    {
        private readonly SportDbContext _context;

        public StoreApprovalsController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StoreApprovalsController
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

                List<StoreItemInUse> storeItems = _context.StoreItemInUse.Include("StoreItem").Include("Event")
                    .Include("SportDiscipine").
                    ToList();
                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", storeItems);
                }
                catch (Exception ex) { }
                return View(storeItems);
            }
            catch(Exception ex)
            {

            }
            return View();
        }

        // GET: StoreApprovalsController/Details/5
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
            return View();
        }

        // GET: StoreApprovalsController/Create
        public ActionResult Create()
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

        // POST: StoreApprovalsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: StoreApprovalsController/Edit/5
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
                StoreItemInUse storeItemInUse = _context.StoreItemInUse.Include("StoreItem").Include("Event")
                    .Include("SportDiscipine").SingleOrDefault();
                
                return View(storeItemInUse);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StoreApprovalsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, StoreItemInUse collection,string status)
        {
            try
            {
                StoreItemInUse storeItemInUse = null;
                if (status != null)
                {
                    storeItemInUse = _context.StoreItemInUse.Where(s => s.Id.Equals(id)).SingleOrDefault();
                    if (storeItemInUse != null)
                    {
                        if (status.Equals("reject"))
                        {
                            storeItemInUse.Approved = false;
                            storeItemInUse.Rejected = true;
                        }else if (status.Equals("accept"))
                        {
                            storeItemInUse.Approved = true;
                            storeItemInUse.Rejected = false;
                        }
                        storeItemInUse.DateApproved = DateTime.Now;
                        _context.StoreItemInUse.Update(storeItemInUse);
                        await _context.SaveChangesAsync();
                    }

                }
                ViewBag.Success = status.Equals("accept")?"Items approved successfully!": "Items rejected successfully!";
                TempData["Success"] = status.Equals("accept") ? "Items approved successfully!" : "Items rejected successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: StoreApprovalsController/Delete/5
        public ActionResult Delete(int id)
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

        // POST: StoreApprovalsController/Delete/5
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
                        Style normal = new Style();
                        PdfFont font = PdfFontFactory.CreateFont(FontConstants.TIMES_ROMAN);
                        normal.SetFont(font).SetFontSize(11);
                        String line = "REPORT";
                        document.Add(new Paragraph(line));

                        try
                        {
                            List<StoreItemInUse> students = SessionHelper.GetObjectFromJson<List<StoreItemInUse>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1, 1, 1,1,1,1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("StoreItem", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Event", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Sport Discipine", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Approved", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Returned", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("DateRequested", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("DateApproved", (float)0.5, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("DateReturned", (float)0.5, 1, TextAlignment.LEFT));

                                    foreach (StoreItemInUse student in students)
                                    {
                                        table.AddCell(createCell(student.StoreItem.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Event.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.SportDiscipine.Name, (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Approved?"Yes":"No", (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Returned?"Yes":"No", (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.DateRequested.ToString(), (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.DateApproved.ToString(), (float)0.5, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.DateReturned.ToString(), (float)0.5, 1, TextAlignment.LEFT));
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
