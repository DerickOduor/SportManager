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
    public class StoreCategoryController : Controller
    {
        private readonly SportDbContext _context;

        public StoreCategoryController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StoreController
        public async Task<ActionResult> Index(Guid id)
        {
            if (TempData["Success"] != null)
            {
                ViewBag.Success = TempData["Success"];
            }
            if (TempData["Failed"] != null)
            {
                ViewBag.Failed = TempData["Failed"];
            }
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return RedirectToAction("Index", "Store");
                }
                ViewBag.StoreCategory = _context.StoreCategories.Where(s => s.Id.Equals(id)).SingleOrDefault().Name;
                ViewBag.StoreCategoryId = _context.StoreCategories.Where(s => s.Id.Equals(id)).SingleOrDefault().Id;
                List<StoreItem> storeItems = _context.StoreItems.Include("StoreCategory").Include("StoreItemsInUse").Where(s => s.StoreCategoryId.Equals(id)).ToList();

                try
                {
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", "");
                    SessionHelper.SetObjectAsJson(HttpContext.Session, "REPORT", storeItems);
                }
                catch (Exception ex) { }

                return View(storeItems);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: StoreCategoryController/Details/5
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

        // GET: StoreCategoryController/Create
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

        // POST: StoreCategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreCategory collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }

                StoreCategory storeCategory = _context.StoreCategories.Where(s => s.Name.Equals(collection.Name)).SingleOrDefault();
                if (storeCategory != null)
                {
                    ViewBag.Failed = "Category with the same name already exists!";
                    return View();
                }
                collection.Id = Guid.Empty;
                _context.StoreCategories.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Item saved successfully!";
                TempData["Success"] = "Item saved successfully!";
                //return RedirectToAction(nameof(Index));

                return RedirectToAction(nameof(Index), "Store");
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: StoreCategoryController/Edit/5
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
                StoreCategory storeCategory = _context.StoreCategories.Include("StoreItems").Where(s => s.Id.Equals(id)).SingleOrDefault();
                return View(storeCategory);
            }catch(Exception ex)
            {

            }
            return View();
        }

        // POST: StoreCategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, StoreCategory collection)
        {
            try
            {
                StoreCategory storeCategory = _context.StoreCategories.Include("StoreItems").Where(s => s.Name.Equals(collection.Name)).SingleOrDefault();
                if (storeCategory != null)
                {
                    if (storeCategory.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "An item with the same name already exists!";
                        return View();
                    }
                }

                _context.StoreCategories.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Item updated successfully!";
                TempData["Success"] = "Item updated successfully!";
                //return RedirectToAction(nameof(Index),id);
                return RedirectToAction(nameof(Index), "Store");
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreCategoryController/Delete/5
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
                StoreCategory storeCategory = _context.StoreCategories.Include("StoreItems").Where(s => s.Id.Equals(id)).SingleOrDefault();
                return View(storeCategory);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: StoreCategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, StoreCategory collection)
        {
            try
            {
                StoreCategory storeCategory = _context.StoreCategories.Include("StoreItems").Where(s => s.Id.Equals(collection.Id)).SingleOrDefault();
                if (storeCategory != null)
                {
                    _context.StoreCategories.Remove(storeCategory);
                    await _context.SaveChangesAsync();
                    ViewBag.Success = "Item deleted successfully!";
                    TempData["Success"] = "Item deleted successfully!";
                    return RedirectToAction(nameof(Index),"Store");
                }

                ViewBag.Failed = "Item deletion failed!";
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
                            List<StoreItem> students = SessionHelper.GetObjectFromJson<List<StoreItem>>(HttpContext.Session, "REPORT");
                            if (students != null)
                            {
                                if (students.Count > 0)
                                {
                                    Table table = new Table(new float[] { 1, 1, 1});
                                    table.SetWidth(100);
                                    table.AddCell(createCell("Name", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Quantity", 1, 1, TextAlignment.LEFT));
                                    table.AddCell(createCell("Category", 1, 1, TextAlignment.LEFT));
                                    //table.AddCell(createCell("SportDiscipine", 1, 1, TextAlignment.LEFT));

                                    foreach (StoreItem student in students)
                                    {
                                        table.AddCell(createCell(student.Name, 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.Count+"", 1, 1, TextAlignment.LEFT));
                                        table.AddCell(createCell(student.StoreCategory.Name, 1, 1, TextAlignment.LEFT));
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
