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
    public class DisciplineEventsController : Controller
    {
        private readonly SportDbContext _context;

        public DisciplineEventsController(SportDbContext context)
        {
            _context = context;
        }
        // GET: DisciplineEventsController
        public async Task<ActionResult> Index(int id)
        {
            Staff staff = null;
            try
            {
                staff = SessionHelper.GetObjectFromJson<Staff>(HttpContext.Session, "MY_l_USER");
                if (staff != null)
                {
                    staff = _context.Staffs.Include("SportDiscipinePatron").Where(s => s.Id.Equals(staff.Id)).SingleOrDefault();
                    try
                    {
                        Profile profile = _context.Profiles.Where(p => p.Id.Equals(staff.ProfileId)).SingleOrDefault();
                        if (profile.Name.Equals("Coordinator") || profile.Name.Equals("Secretary"))
                            ViewBag.CanAddEvent = true;
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
                List<EventType> eventTypes = _context.EventTypes.ToList();
                ViewBag.EventTypes = eventTypes;

                List<Event> events = _context.Events.Include("SportDisciplinesInEvent").ToList();
                List<Event> events_ = new List<Event>();
                foreach (Event _event in events)
                {
                    foreach(SportDisciplinesInEvent inEvent in _event.SportDisciplinesInEvent)
                    {
                        if (inEvent.SportDiscipineId.Equals(staff.SportDiscipinePatron.SportDiscipineId))
                            events_.Add(_event);
                    }
                    
                }
                if (id != null)
                {
                    if (id == 1)
                    {
                        events_ = events_.Where(e => e.PostPoned).ToList();
                    }
                    else if (id == 2)
                    {
                        events_ = events_.Where(e => e.Cancelled).ToList();
                    }
                }
                return View(events_);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: DisciplineEventsController/Details/5
        public async Task<ActionResult> Details(int id)
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

        // GET: DisciplineEventsController/Create
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

        // POST: DisciplineEventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
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

        // GET: DisciplineEventsController/Edit/5
        public async Task<ActionResult> Edit(int id)
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

        // POST: DisciplineEventsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
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

        // GET: DisciplineEventsController/Delete/5
        public async Task<ActionResult> Delete(int id)
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

        // POST: DisciplineEventsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
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
