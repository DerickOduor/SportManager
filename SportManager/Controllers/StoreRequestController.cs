using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportManager.Models;
using SportManager.Models.Context;

namespace SportManager.Controllers
{
    public class StoreRequestController : Controller
    {
        private readonly SportDbContext _context;

        public StoreRequestController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StoreRequestController
        public async Task<ActionResult> Index()
        {
            Staff staff = null;
            try
            {
                staff = SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff == null)
                {
                    return RedirectToAction("Index", "Logout");
                }
                staff = _context.Staffs.Include("SportDiscipinePatron").Where(s => s.Id.Equals(staff.Id)).SingleOrDefault();
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

                Profile profile = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault();

                List<StoreItemInUse> storeItems = _context.StoreItemInUse.Include("StoreItem").Include("Event")
                    .Include("SportDiscipine").Where(s=>s.SportDiscipineId.Equals(staff.SportDiscipinePatron.SportDiscipineId)).
                    ToList();

                return View(storeItems);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: StoreRequestController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                StoreItemInUse storeItem = _context.StoreItemInUse.Include("StoreItem").Include("Event").Include("SportDiscipine").Where(s=>s.Id.Equals(id)).SingleOrDefault();
                return View(storeItem);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: StoreRequestController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                List<Event> events = _context.Events.Where(e => e.EndDate > DateTime.Now & !e.Cancelled).ToList();
                ViewBag.Events = new SelectList(events, "Id", "Name");
                List<StoreCategory> storeCategories = _context.StoreCategories.Include("StoreItems").ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                ViewBag.StoreCategoriesItems = storeCategories;
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StoreRequestController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StoreItemInUse collection,string SportCategoryId)
        {
            Staff staff = null;
            try
            {
                staff= SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff == null)
                {
                    return RedirectToAction("Index","Logout");
                }
                staff = _context.Staffs.Include("SportDiscipinePatron").Where(s => s.Id.Equals(staff.Id)).SingleOrDefault();
                List<Event> events = _context.Events.Where(e => e.EndDate > DateTime.Now & !e.Cancelled).ToList();
                ViewBag.Events = new SelectList(events, "Id", "Name");
                List<StoreCategory> storeCategories = _context.StoreCategories.Include("StoreItems").ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                ViewBag.StoreCategoriesItems = storeCategories;
            }
            catch (Exception ex) { }
            try
            {
                StoreItemInUse storeItem = _context.StoreItemInUse.Where(s => s.StoreItemId.Equals(collection.StoreItemId)
                      & s.EventId.Equals(collection.EventId) & s.SportDiscipineId.Equals(staff.SportDiscipinePatron.SportDiscipineId)
                      ).SingleOrDefault();

                if (storeItem != null)
                {
                    ViewBag.Failed = "This item has already been requested for!";
                    return View();
                }

                collection.SportDiscipineId = staff.SportDiscipinePatron.SportDiscipineId;
                collection.Approved = false;
                collection.Rejected = false;
                collection.DateRequested = DateTime.Now;
                collection.Id = Guid.Empty;

                _context.StoreItemInUse.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Items requested successfully!";
                TempData["Success"] = "Items requested successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: StoreRequestController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                List<Event> events = _context.Events.Where(e => e.EndDate > DateTime.Now & !e.Cancelled).ToList();
                ViewBag.Events = new SelectList(events, "Id", "Name");
                List<StoreCategory> storeCategories = _context.StoreCategories.Include("StoreItems").ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                ViewBag.StoreCategoriesItems = storeCategories;
            }
            catch (Exception ex) { }
            try
            {
                StoreItemInUse storeItem = _context.StoreItemInUse.Include("StoreItem").Include("Event").Include("SportDiscipine").Where(s => s.Id.Equals(id)).SingleOrDefault();
                return View(storeItem);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StoreRequestController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, StoreItemInUse collection)
        {
            try
            {
                List<Event> events = _context.Events.Where(e => e.EndDate > DateTime.Now & !e.Cancelled).ToList();
                ViewBag.Events = new SelectList(events, "Id", "Name");
                List<StoreCategory> storeCategories = _context.StoreCategories.Include("StoreItems").ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                ViewBag.StoreCategoriesItems = storeCategories;
            }
            catch (Exception ex) { }
            try
            {
                StoreItemInUse itemInUse = _context.StoreItemInUse.Where(s => s.Id.Equals(id)).SingleOrDefault();
                if (itemInUse != null)
                {
                    itemInUse.Count = collection.Count;
                }

                //_context.StoreItemInUse.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Items edited successfully!";
                TempData["Success"] = "Items edited successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreRequestController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                List<Event> events = _context.Events.Where(e => e.EndDate > DateTime.Now & !e.Cancelled).ToList();
                ViewBag.Events = new SelectList(events, "Id", "Name");
                List<StoreCategory> storeCategories = _context.StoreCategories.Include("StoreItems").ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                ViewBag.StoreCategoriesItems = storeCategories;
            }
            catch (Exception ex) { }
            try
            {
                StoreItemInUse storeItem = _context.StoreItemInUse.Include("StoreItem").Include("Event").Include("SportDiscipine").Where(s => s.Id.Equals(id)).SingleOrDefault();
                return View(storeItem);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StoreRequestController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, StoreItemInUse collection)
        {
            try
            {
                List<Event> events = _context.Events.Where(e => e.EndDate > DateTime.Now & !e.Cancelled).ToList();
                ViewBag.Events = new SelectList(events, "Id", "Name");
                List<StoreCategory> storeCategories = _context.StoreCategories.Include("StoreItems").ToList();
                ViewBag.StoreCategories = new SelectList(storeCategories, "Id", "Name");
                ViewBag.StoreCategoriesItems = storeCategories;
            }
            catch (Exception ex) { }
            try
            {
                StoreItemInUse itemInUse = _context.StoreItemInUse.Where(s => s.Id.Equals(collection.Id)).SingleOrDefault();
                if (itemInUse != null)
                {
                    _context.StoreItemInUse.Remove(itemInUse);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Items cancelled successfully!";
                TempData["Success"] = "Items cancelled successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        public async Task<ActionResult> FetchStoreItems(Guid id)
        {
            try
            {
                List<StoreItem> storeItems = _context.StoreItems.Where(e => e.StoreCategoryId.Equals(id)).ToList();
                return Content(JsonConvert.SerializeObject(storeItems));
            }
            catch (Exception ex) 
            {
                return Content("");
            }
        }

        public async Task<ActionResult> FetchStoreItem(Guid id)
        {
            try
            {
                List<StoreItem> storeItems = _context.StoreItems.Where(e => e.Id.Equals(id)).ToList();
                return Content(JsonConvert.SerializeObject(storeItems));
            }
            catch (Exception ex) 
            {
                return Content("");
            }
        }
    }
}
