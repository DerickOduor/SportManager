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
    public class EventController : Controller
    {
        private readonly SportDbContext _context;

        public EventController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventController
        public async Task<ActionResult> Index(int id)
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
                List<EventType> eventTypes=_context.EventTypes.ToList();
                ViewBag.EventTypes = eventTypes;

                List<Event> events = _context.Events.ToList();
                if (id != null)
                {
                    if (id == 1)
                    {
                        events = events.Where(e => e.PostPoned).ToList();
                    }
                    else if (id == 2)
                    {
                        events = events.Where(e => e.Cancelled).ToList();
                    }
                }
                return View(events);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            Staff staff = null;
            try
            {
                staff = SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff != null)
                {
                    try
                    {
                        Profile profile = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault();
                        if (/*staff.Profile*/profile.Name.Equals("Secretary") || /*staff.Profile*/profile.Name.Equals("Coordinator"))
                            ViewBag.CanAddDiscipline = true;
                    }
                    catch (Exception ex) { }
                }
                Event @event = _context.Events.Include("Teams").Include("StoreItemsInUse").Include("EventSessions").
                    Include("SportDisciplinesInEvent").
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
                ViewBag.EventTypes = new SelectList(eventTypes, "Id", "Name");
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
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = new SelectList(eventTypes, "Id", "Name");

                Event @event = _context.Events.Where(e => e.Name.Equals(collection.Name.Trim()) & e.StartDate.Equals(collection.StartDate) & e.EndDate.Equals(collection.EndDate)).SingleOrDefault();
                if (@event != null)
                {
                    ViewBag.Failed = "Event with same name and dates already exists!";
                    return View();
                }
                collection.PostPoned = false;
                collection.Cancelled = false;
                collection.Ongoing = false;
                _context.Events.Add(collection);

                await _context.SaveChangesAsync();

                TempData["Success"] = "Event saved successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = new SelectList(eventTypes, "Id", "Name");

                Event @event = _context.Events.Include("Teams").Include("StoreItemsInUse").Include("EventSessions").
                    Where(e => e.Id.Equals(id)).SingleOrDefault();

                return View(@event);

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
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = new SelectList(eventTypes, "Id", "Name");
                Event @event = _context.Events.Where(e => e.Name.Equals(collection.Name.Trim()) & e.StartDate.Equals(collection.StartDate) & e.EndDate.Equals(collection.EndDate)).SingleOrDefault();
                if (@event != null)
                {
                    if (@event.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "Event with same name and dates already exists!";
                        return View();
                    }
                }

                if (collection.PostPoned)
                {
                    collection.NewStartDate = collection.StartDate;
                    collection.NewEndDate = collection.EndDate;
                }

                _context.Events.Update(collection);

                await _context.SaveChangesAsync();
                TempData["Success"] = "Event edited successfully!";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                Event @event = _context.Events.Include("Teams").Include("StoreItemsInUse").Include("EventSessions").
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
