using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;

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
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index", "Store");
                }
                ViewBag.StoreCategory = _context.StoreCategories.Where(s => s.Id.Equals(id)).SingleOrDefault().Name;
                ViewBag.StoreCategoryId = _context.StoreCategories.Where(s => s.Id.Equals(id)).SingleOrDefault().Id;
                List<StoreItem> storeItems = _context.StoreItems.Include(nameof(StoreItemInUse)).Where(s => s.StoreCategoryId.Equals(id)).ToList();
                return View(storeItems);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: StoreCategoryController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            return View();
        }

        // GET: StoreCategoryController/Create
        public async Task<ActionResult> Create()
        {
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

                _context.StoreCategories.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Item saved successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreCategoryController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                StoreCategory storeCategory = _context.StoreCategories.Include(nameof(StoreItem)).Where(s => s.Id.Equals(id)).SingleOrDefault();
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
                StoreCategory storeCategory = _context.StoreCategories.Where(s => s.Name.Equals(collection.Name)).SingleOrDefault();
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
                return RedirectToAction(nameof(Index));
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
                StoreCategory storeCategory = _context.StoreCategories.Include(nameof(StoreItem)).Where(s => s.Id.Equals(id)).SingleOrDefault();
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
                StoreCategory storeCategory = _context.StoreCategories.Where(s => s.Id.Equals(collection.Id)).SingleOrDefault();
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
    }
}
