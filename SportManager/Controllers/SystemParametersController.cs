using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SportManager.Models;
using SportManager.Models.Context;
using SportManager.Models.Utils;

namespace SportManager.Controllers
{
    public class SystemParametersController : Controller
    {
        private readonly SportDbContext _context;

        public SystemParametersController(SportDbContext context)
        {
            _context = context;
        }
        // GET: SystemParametersController
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
                List<Parameter> parameters = _context.Parameters.ToList();

                return View(parameters);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: SystemParametersController/Details/5
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
                Parameter parameter = _context.Parameters.Where(p => p.Id.Equals(id)).SingleOrDefault();

                return View(parameter);
            }
            catch (Exception ex) { }
            return View();
        }

        // GET: SystemParametersController/Create
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

        // POST: SystemParametersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Parameter collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Parameter parameter = _context.Parameters.Where(p => p.Name.Equals(collection.Name)).SingleOrDefault();
                if (parameter != null)
                {
                    ViewBag.Failed = "Parameter with the same name already exist!";
                    return View();
                }
                if (collection.IsPassword)
                    collection.Value = AppUtility.Encrypt(collection.Value);

                _context.Parameters.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Parameter added successfully!";
                TempData["Success"] = "Parameter added successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: SystemParametersController/Edit/5
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
                Parameter parameter = _context.Parameters.Where(p => p.Id.Equals(id)).SingleOrDefault();

                return View(parameter);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SystemParametersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Guid id, Parameter collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                Parameter parameter = _context.Parameters.Where(p => p.Name.Equals(collection.Name)).SingleOrDefault();
                if (parameter != null)
                {
                    if (!parameter.Id.Equals(collection.Id))
                    {
                        ViewBag.Failed = "Parameter with the same name already exist!";
                        return View();
                    }
                }

                if (collection.IsPassword)
                    collection.Value = AppUtility.Encrypt(collection.Value);

                _context.Parameters.Update(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Parameter updated successfully!";
                TempData["Success"] = "Parameter updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }

        // GET: SystemParametersController/Delete/5
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
                Parameter parameter = _context.Parameters.Where(p => p.Id.Equals(id)).SingleOrDefault();

                return View(parameter);
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: SystemParametersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, Parameter collection)
        {
            try
            {
                Parameter parameter = _context.Parameters.Where(p => p.Id.Equals(collection.Id)).SingleOrDefault();
                if (parameter != null)
                {
                    _context.Parameters.Remove(parameter);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Parameter updated successfully!";
                TempData["Success"] = "Parameter updated successfully!";

                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                return View();
            }
        }
    }
}
