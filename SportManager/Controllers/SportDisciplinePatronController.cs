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
    public class SportDisciplinePatronController : Controller
    {
        private readonly SportDbContext _context;

        public SportDisciplinePatronController(SportDbContext context)
        {
            _context = context;
        }
        // GET: SportDisciplinePatronController
        public async Task<ActionResult> Index(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return RedirectToAction("Index", "Sport");

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
                ViewBag.SpoortDiscipline = _context.SportDiscipines.Where(s => s.Id.Equals(id)).SingleOrDefault();
                Profile profile = _context.Profiles.Where(p => p.Name.Equals("Patron")).SingleOrDefault();
                List<Staff> staffs = _context.Staffs.Where(s=>s.ProfileId.Equals(profile.Id)).ToList();
                ViewBag.Staffs = new SelectList(staffs, "Id", "RegistrationNumber");
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: SportDisciplinePatronController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: SportDisciplinePatronController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: SportDisciplinePatronController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(SportDiscipinePatron collection)
        {
            try
            {
                ViewBag.SpoortDiscipline = _context.SportDiscipines.Where(s => s.Id.Equals(collection.SportDiscipineId)).SingleOrDefault();
                Profile profile = _context.Profiles.Where(p => p.Name.Equals("Patron")).SingleOrDefault();
                List<Staff> staffs = _context.Staffs.Where(s => s.ProfileId.Equals(profile.Id)).ToList();
                ViewBag.Staffs = new SelectList(staffs, "Id", "RegistrationNumber");
            }
            catch (Exception ex) { }
            try
            {
                SportDiscipinePatron sportDiscipine = _context.SportDiscipinePatrons.Where(s => s.SportDiscipineId.Equals(collection.SportDiscipineId)
                      & s.StaffId.Equals(collection.StaffId)).SingleOrDefault();

                if (sportDiscipine != null)
                {
                    ViewBag.Failed = "Discipline already assigned patron! Did you intend to edit?";
                    return View();
                }

                collection.Id = Guid.Empty;

                _context.SportDiscipinePatrons.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Patron assigned successfully!";
                TempData["Success"] = "Patron assigned successfully!";

                return RedirectToAction(nameof(Index),"Sport");
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
                return RedirectToAction(nameof(Index),new { id= collection.SportDiscipineId });
                //return View();
            }
        }

        // GET: SportDisciplinePatronController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            try
            {
                if (id.Equals(Guid.Empty))
                    return RedirectToAction("Index", "Sport");

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
                SportDiscipine discipine=_context.SportDiscipines.Where(s => s.Id.Equals(id)).SingleOrDefault();
                SportDiscipinePatron discipinePatron = _context.SportDiscipinePatrons.Include("SportDiscipine").Include("Staff")
                    .Where(s => s.SportDiscipineId.Equals(id)).SingleOrDefault();
                ViewBag.SpoortDiscipline = discipine;
                Profile profile = _context.Profiles.Where(p => p.Name.Equals("Patron")).SingleOrDefault();
                List<Staff> staffs = _context.Staffs.Where(s => s.ProfileId.Equals(profile.Id)).ToList();
                Staff currentPatron = staffs.Where(s => s.Id.Equals(discipinePatron.StaffId)).SingleOrDefault();
                ViewBag.Staffs = new SelectList(staffs, "Id", "RegistrationNumber");

                return View(discipinePatron);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SportDisciplinePatronController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, SportDiscipinePatron collection)
        {
            try
            {
                SportDiscipine discipine = _context.SportDiscipines.Where(s => s.Id.Equals(collection.SportDiscipineId)).SingleOrDefault();
                SportDiscipinePatron discipinePatron = _context.SportDiscipinePatrons.Where(s => s.Id.Equals(collection.Id)).SingleOrDefault();
                ViewBag.SpoortDiscipline = discipine;
                Profile profile = _context.Profiles.Where(p => p.Name.Equals("Patron")).SingleOrDefault();
                List<Staff> staffs = _context.Staffs.Where(s => s.ProfileId.Equals(profile.Id)).ToList();
                Staff currentPatron = staffs.Where(s => s.Id.Equals(discipinePatron.StaffId)).SingleOrDefault();
                ViewBag.Staffs = new SelectList(staffs, "Id", "RegistrationNumber");
            }
            catch (Exception ex) { }
            try
            {
                SportDiscipinePatron sportDiscipine = _context.SportDiscipinePatrons.Where(s => s.SportDiscipineId.Equals(collection.SportDiscipineId)
                      & s.Id.Equals(collection.Id)).SingleOrDefault();

                if (sportDiscipine != null)
                {
                    sportDiscipine.StaffId = collection.StaffId;
                    _context.SportDiscipinePatrons.Update(sportDiscipine);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Patron updated successfully!";
                TempData["Success"] = "Patron updated successfully!";

                return RedirectToAction(nameof(Index),"Sport");
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
                return RedirectToAction(nameof(Edit), new { id= collection.SportDiscipineId });
            }
        }

        // GET: SportDisciplinePatronController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: SportDisciplinePatronController/Delete/5
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
