using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Borders;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;

namespace SportManager.Controllers
{
    public class StudentsController : Controller
    {

        private readonly SportDbContext _context;

        public StudentsController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StudentsController
        public async Task<ActionResult> Index(Guid id)
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

                List<Student> students = _context.Students.Include("SportDiscipine").Include("StudentsParticipatingInEvent")
                    .ToList();
                if (!id.Equals(Guid.Empty))
                    students = students.Where(s => s.SportDiscipineId.Equals(id)).ToList();
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

        // GET: StudentsController/Details/5
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
                Student student = _context.Students.Include("SportDiscipine").Include("StudentsParticipatingInEvent")
                    .Where(s => s.Id.Equals(id)).SingleOrDefault();

                return View(student);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: StudentsController/Create
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

        // POST: StudentsController/Create
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

        // GET: StudentsController/Edit/5
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

        // POST: StudentsController/Edit/5
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

        // GET: StudentsController/Delete/5
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

        // POST: StudentsController/Delete/5
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
                        String line = "Students";
                        document.Add(new Paragraph(line));

                        try
                        {
                            List<Student> students= SessionHelper.GetObjectFromJson<List<Student>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1, 1, 1 });
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Reg. No.", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Name", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Email", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Phone", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach(Student student in students)
                                    {
                                        table.AddCell(createCell(student.RegistrationNumber, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Firstname+" "+student.Lastname, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Email, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Phone, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.SportDiscipine.Name, 1, 1, TextAlignment.LEFT));
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
