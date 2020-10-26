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
                List<Venue> venues = _context.Venues.ToList();
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
                Venue venue =await  _context.Venues.Where(v=>v.Id.Equals(id)).SingleOrDefaultAsync();
                return View(venue);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: VenueController/Create
        public async Task<ActionResult> Create()
        {
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
        public async Task<ActionResult> Edit(int id)
        {
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
        public async Task<ActionResult> Delete(int id)
        {
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
    }
}
