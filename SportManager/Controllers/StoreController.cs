﻿using System;
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
    public class StoreController : Controller
    {
        private readonly SportDbContext _context;

        public StoreController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StoreController
        public async Task<ActionResult> Index()
        {
            try
            {
                ViewBag.Store = _context.Stores.ToList().ElementAt(0).Name;
                List<StoreCategory> storeCategories = _context.StoreCategories.Include(nameof(StoreItem)).ToList();

                return View(storeCategories);
            }catch(Exception ex)
            {

            }
            return View();
        }

        // GET: StoreController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: StoreController/Create
        public async Task<ActionResult> Create()
        {
            return View();
        }

        // POST: StoreController/Create
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

        // GET: StoreController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
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

        // GET: StoreController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
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