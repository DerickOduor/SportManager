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
            return View();
        }

        // GET: StoreApprovalsController/Create
        public ActionResult Create()
        {
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
    }
}
