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
    public class EventSessionController : Controller
    {
        private readonly SportDbContext _context;

        public EventSessionController(SportDbContext context)
        {
            _context = context;
        }
        // GET: EventSessionController
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
                        Profile profile = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault();
                        if (/*staff.Profile*/profile.Name.Equals("Secretary") || /*staff.Profile*/profile.Name.Equals("Coordinator"))
                            ViewBag.CanAddSession = true;
                    }
                    catch (Exception ex) { }
                }
            }
            catch (Exception ex) { }
            try
            {
                if (id.Equals(Guid.Empty))
                {
                    return RedirectToAction("Index","Event");
                }
                if (TempData["Success"] != null)
                {
                    ViewBag.Success = TempData["Success"];
                }
                if (TempData["Failed"] != null)
                {
                    ViewBag.Failed = TempData["Failed"];
                }
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<EventSession> eventSessions = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.EventId.Equals(id)).ToList();
                return View(eventSessions);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: EventSessionController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            try
            {
                EventSession eventSession = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.Id.Equals(id)).SingleOrDefault();
                return View(eventSession);
            }catch(Exception ex)
            {
                
            }
            return View();
        }

        // GET: EventSessionController/Create
        public async Task<ActionResult> Create(Guid id)
        {
            try
            {
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<Venue> venues= _context.Venues.ToList();
                ViewBag.Venues = new SelectList(venues, "Id", "Name");
            }
            catch(Exception ex)
            {
                
            }
            return View();
        }

        // POST: EventSessionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EventSession collection)
        {
            try
            {
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(collection.EventId)).SingleOrDefault();
                List<Venue> venues = _context.Venues.ToList();
                ViewBag.Venues = new SelectList(venues, "Id", "Name");
                if (!ModelState.IsValid)
                {
                    return View();
                }
                EventSession eventSession = _context.EventSessions.Where(e => e.Name.Equals(collection.Name) & e.EventId.Equals(collection.EventId)).SingleOrDefault();
                if (eventSession != null)
                {
                    ViewBag.Failed="Session with the same name already exists!";
                    return View();
                }
                try
                {
                    List<EventSession> sessions = _context.EventSessions.Include("Event").ToList();
                    if (sessions != null)
                    {
                        foreach(EventSession session in sessions)
                        {
                            if(session.StartTime<collection.StartTime & session.EndTime > collection.EndTime)
                            {
                                if (session.VenueId.Equals(collection.VenueId))
                                {
                                    ViewBag.Failed = "Venue already booked for Session: "+session.Name+", Event:"+session.Event.Name;
                                    return View();
                                }
                            }
                        }
                    }
                }catch(Exception ex)
                {

                }
                collection.Id = Guid.Empty;
                _context.EventSessions.Add(collection);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Session added successfully";
                return RedirectToAction(nameof(Index),collection.EventId);
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventSessionController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(id)).SingleOrDefault();
                List<Venue> venues = _context.Venues.ToList();
                ViewBag.Venues = new SelectList(venues, "Id", "Name");
                EventSession eventSession = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.Id.Equals(id)).SingleOrDefault();
                return View(eventSession);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: EventSessionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, EventSession collection)
        {
            try
            {
                ViewBag.Event = _context.Events.Where(e => e.Id.Equals(collection.EventId)).SingleOrDefault();
                ViewBag.Venues = _context.Venues.ToList();
                if (!ModelState.IsValid)
                {
                    return View();
                }
                EventSession eventSession = _context.EventSessions.Where(e => e.Name.Equals(collection.Name) & e.EventId.Equals(collection.EventId)).SingleOrDefault();
                if (eventSession != null)
                {
                    if (eventSession.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "Session with the same name already exists!";
                        return View();
                    }
                }

                _context.EventSessions.Add(collection);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Session edited successfully";
                return RedirectToAction(nameof(Index), collection.EventId);
            }
            catch
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: EventSessionController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                EventSession eventSession = _context.EventSessions.Include(nameof(Event)).Include(nameof(Venue)).Where(e => e.Id.Equals(id)).SingleOrDefault();
                return View(eventSession);
            }
            catch (Exception ex)
            {

            }
            return View();
        }

        // POST: EventSessionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, EventSession collection)
        {
            Guid event_id=Guid.NewGuid();
            try
            {
                EventSession eventSession = _context.EventSessions.Where(e => e.Id.Equals(collection.Id)).SingleOrDefault();
                event_id = eventSession.EventId;
                _context.EventSessions.Remove(eventSession);
                await _context.SaveChangesAsync();

                TempData["Success"] = "Session deleted successfully";
                return RedirectToAction(nameof(Index), event_id);
            }
            catch
            {
                ViewBag.Failed="An error occured!";
                //return View();
                return RedirectToAction(nameof(Delete), event_id);
            }
        }
    }
}
