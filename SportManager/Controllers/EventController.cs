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
    public class EventController : Controller
    {
        private readonly SportDbContext _context;

        public EventController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventController
        public async Task<ActionResult> Index()
        {
            try
            {
                List<EventType> eventTypes=_context.EventTypes.ToList();
                ViewBag.EventTypes = eventTypes;

                List<Event> events = _context.Events.ToList(); 
                return View(events);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                Event @event = _context.Events.Include(nameof(Team)).Include(nameof(StoreItemInUse)).Include(nameof(EventSession)).
                    Where(e => e.Id.Equals(id)).SingleOrDefault();

                ViewBag.EventType = _context.EventTypes.Where(e => e.Id.Equals(@event.EventTypeId)).SingleOrDefault().Name;

                return View(@event);

            }catch(Exception ex)
            {

            }
            return View();
        }

        // GET: EventController/Create
        public async Task<ActionResult> Create()
        {
            try
            {
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = eventTypes;
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Event collection)
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

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = eventTypes;
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: EventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Event collection)
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

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                Event @event = _context.Events.Include(nameof(Team)).Include(nameof(StoreItemInUse)).Include(nameof(EventSession)).
                    Where(e => e.Id.Equals(id)).SingleOrDefault();

                ViewBag.EventType = _context.EventTypes.Where(e => e.Id.Equals(@event.EventTypeId)).SingleOrDefault().Name;

                return View(@event);

            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: EventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Event collection)
        {
            try
            {
                Event @event = _context.Events.Where(e => e.Id.Equals(collection.Id)).SingleOrDefault();
                if (@event != null)
                {
                    _context.Events.Remove(@event);
                    await _context.SaveChangesAsync();
                    TempData["Success"] = "Event deleted successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ViewBag.Failed = "Event deletion failed!";
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
