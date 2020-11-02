using System;
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
    public class EventDisciplinesController : Controller
    {
        private readonly SportDbContext _context;

        public EventDisciplinesController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventDisciplinesController
        public async Task<ActionResult> Index(Guid id)
        {
            Staff staff = null;
            try
            {
                staff = SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff != null)
                {
                    try
                    {
                        if (staff.Profile.Name.Equals("Secretary") || staff.Profile.Name.Equals("Coordinator"))
                            ViewBag.CanAddDiscipline = true;
                    }
                    catch (Exception ex) { }
                }
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

                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }
                List<SportDisciplinesInEvent> sportDisciplinesInEvent = _context.SportDisciplinesInEvents
                    .Include("Event").Include("SportDiscipine").ToList();
                
                return View(sportDisciplinesInEvent);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventDisciplinesController/Details/5
        public ActionResult Details(Guid id)
        {
            return View();
        }

        // GET: EventDisciplinesController/Create
        public async Task<ActionResult> Create(Guid id)
        {
            try
            {
                if (id == null)
                {
                    return RedirectToAction("Index", "Home");
                }

                Event _event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                ViewBag.Event = _event;
                List<SportDiscipine> sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.SportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventDisciplinesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SportDisciplinesInEvent collection)
        {
            try
            {
                Event _event = _context.Events.Where(e => e.Id.Equals(collection.EventId)).SingleOrDefault();
                ViewBag.Event = _event;
                List<SportDiscipine> sportDiscipines = _context.SportDiscipines.ToList();
                ViewBag.SportDiscipines = new SelectList(sportDiscipines, "Id", "Name");
            }
            catch (Exception ex) { }
            try
            {
                SportDisciplinesInEvent sportDisciplinesInEvent = _context.SportDisciplinesInEvents.Where(s => s.EventId.Equals(collection.EventId)
                      & s.SportDiscipineId.Equals(collection.SportDiscipineId)).SingleOrDefault();

                if (sportDisciplinesInEvent != null)
                {
                    ViewBag.Failed = "Discipline already exists in this event!";
                    return View();
                }

                _context.SportDisciplinesInEvents.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Discipline added successfully to event!";
                TempData["Success"] = "Discipline added successfully to event!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventDisciplinesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EventDisciplinesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: EventDisciplinesController/Delete/5
        public async Task<ActionResult> Delete(Guid id,Guid jd)
        {
            try
            {
                SportDisciplinesInEvent sportDisciplinesInEvent = _context.SportDisciplinesInEvents.Where(s => s.Id.Equals(id)).SingleOrDefault();
                if (sportDisciplinesInEvent != null)
                {
                    _context.SportDisciplinesInEvents.Remove(sportDisciplinesInEvent);
                    await _context.SaveChangesAsync();

                    ViewBag.Success = "Removed successfully!";
                    TempData["Success"] = "Removed successfully!";
                    return RedirectToAction("Index", jd);
                }
            }
            catch (Exception ex) { }
            ViewBag.Failed = "An error occured!";
            TempData["Failed"] = "An error occured!";
            return RedirectToAction("Index",jd);
        }

        // POST: EventDisciplinesController/Delete/5
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
