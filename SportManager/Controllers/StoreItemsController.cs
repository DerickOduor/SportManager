﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportManager.Models;
using SportManager.Models.Context;

namespace SportManager.Controllers
{
    public class StoreItemsController : Controller
    {
        private readonly SportDbContext _context;

        public StoreItemsController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StoreItemsController
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
            return View();
        }

        // GET: StoreItemsController/Details/5
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
                StoreItem storeItem = _context.StoreItems.Include("StoreCategory").Include("StoreItemsInUse").Where(s => s.Id.Equals(id)).SingleOrDefault();
                ViewBag.StoreCategory = _context.StoreCategories.Where(s => s.Id.Equals(storeItem.StoreCategoryId)).SingleOrDefault().Name;
                return View(storeItem);
            }catch(Exception ex)
            {

            }
            return View();
        }

        // GET: StoreItemsController/Create
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
                if (id != null)
                {
                    ViewBag.StoreCategoryId = id;
                    ViewBag.StoreCategory = _context.StoreCategories.Where(s => s.Id.Equals(id)).SingleOrDefault();
                }
                List<StoreCategory> storeCategories = _context.StoreCategories.ToList();
                ViewBag.StoreCategories=new SelectList(storeCategories, "Id", "Name");
            }
            catch(Exception ex)
            {
                
            }
            return View();
        }

        // POST: StoreItemsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreItem collection)
        {
            try
            {
                List<StoreCategory> storeCategories = _context.StoreCategories.ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");

                if (!ModelState.IsValid)
                {
                    return View();
                }

                StoreItem storeItem = _context.StoreItems.Where(s => s.Name.Equals(collection.Name) & s.StoreCategoryId.Equals(collection.StoreCategoryId)).SingleOrDefault();
                if (storeItem != null)
                {
                    ViewBag.Failed = "An item with the same name already exists!";
                    return View();
                }
                collection.Id = Guid.Empty;
                _context.StoreItems.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Item saved successfully!";
                TempData["Success"] = "Item saved successfully!";
                return RedirectToAction(nameof(Index), "StoreCategory",new { id= collection.StoreCategoryId });
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: StoreItemsController/Edit/5
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
                List<StoreCategory> storeCategories = _context.StoreCategories.ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                StoreItem storeItem = _context.StoreItems.Include("StoreCategory").Include("StoreItemsInUse").Where(s => s.Id.Equals(id)).SingleOrDefault();
                return View(storeItem);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StoreItemsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, StoreItem collection)
        {
            try
            {
                List<StoreCategory> storeCategories = _context.StoreCategories.ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");

                if (!ModelState.IsValid)
                {
                    return View();
                }

                StoreItem storeItem = _context.StoreItems.Where(s => s.Name.Equals(collection.Name) & s.StoreCategoryId.Equals(collection.StoreCategoryId) & s.Count == collection.Count).SingleOrDefault();
                if (storeItem != null)
                {
                    if (storeItem.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "An item with the same name already exists!";
                        return View();
                    }
                }

                _context.StoreItems.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Item updated successfully!";
                TempData["Success"] = "Item updated successfully!";
                return RedirectToAction(nameof(Index), "StoreCategory",new { id= collection.StoreCategoryId });
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: StoreItemsController/Delete/5
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
                List<StoreCategory> storeCategories = _context.StoreCategories.ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                StoreItem storeItem = _context.StoreItems.Include("StoreCategory").Include("StoreItemsInUse").Where(s => s.Id.Equals(id)).SingleOrDefault();
                return View(storeItem);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StoreItemsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, StoreItem collection)
        {
            try
            {
                List<StoreCategory> storeCategories = _context.StoreCategories.ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");

                StoreItem storeItem = _context.StoreItems.Where(s => s.Id.Equals(collection.Id)).SingleOrDefault();
                Guid cat_id=Guid.Empty;
                if (storeItem != null)
                {
                    cat_id = storeItem.StoreCategoryId;
                    _context.StoreItems.Remove(storeItem);
                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Item deleted successfully!";
                    return RedirectToAction(nameof(Index), "StoreCategory", new { id= cat_id });
                }
                ViewBag.Failed = "Deletion failed!";
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
