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
    public class StudentsInEventController : Controller
    {
        private readonly SportDbContext _context;

        public StudentsInEventController(SportDbContext context)
        {
            _context = context;
        }
        // GET: StudentsInEventController
        public async Task<ActionResult> Index(Guid id)
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

                if (id.Equals(Guid.Empty))
                    return RedirectToAction("Index", "Event");

                List<StudentsParticipatingInEvent> students = _context.StudentsParticipatingInEvents
                    .Include("Student").Include("SportDisciplinesInEvent").Include("SportDisciplinesInEvent.Event")
                    .Where(s => s.SportDisciplinesInEventId.Equals(id)).ToList();

                return View(students);

            }
            catch (Exception ex) { }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(int id)
        {
            try
            {
                if (id == 0)
                {

                }
                else if (id == 1)
                {

                }
                else if (id == 2)
                {

                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentsInEventController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            return View();
        }

        // GET: StudentsInEventController/Create
        public async Task<ActionResult> Create(Guid id)
        {
            try
            {
                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Include("Event")
                    .Include("SportDiscipine").Where(s => s.Id.Equals(id)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
                List<Student> students = _context.Students.Include("SportDiscipine")
                    .Where(s => s.SportDiscipineId.Equals(disciplineInEvent.SportDiscipineId)).ToList();
            }
            catch (Exception ex) { }
            return View();
        }

        // POST: StudentsInEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(StudentsParticipatingInEvent collection)
        {
            try
            {
                SportDisciplinesInEvent disciplineInEvent = _context.SportDisciplinesInEvents.Include("Event")
                    .Include("SportDiscipine").Where(s => s.Id.Equals(collection.SportDisciplinesInEventId)).SingleOrDefault();
                ViewBag.SportDisciplineInEvent = disciplineInEvent;
                List<Student> students = _context.Students.Include("SportDiscipine")
                    .Where(s => s.SportDiscipineId.Equals(disciplineInEvent.SportDiscipineId)).ToList();
            }
            catch (Exception ex) { }
            try
            {
                StudentsParticipatingInEvent participatingInEvent = _context.StudentsParticipatingInEvents.Where(s => s.StudentId.Equals(collection.StudentId)
                      & s.SportDisciplinesInEventId.Equals(collection.SportDisciplinesInEventId)).SingleOrDefault();

                if (participatingInEvent != null)
                {
                    ViewBag.Failed = "Student already added to event!";
                    return View();
                }

                collection.Id = Guid.Empty;

                _context.StudentsParticipatingInEvents.Add(collection);
                await _context.SaveChangesAsync();

                ViewBag.Success = "Student added to event successfully!";
                TempData["Success"] = "Student added to event successfully!";

                return RedirectToAction(nameof(Index),collection.SportDisciplinesInEventId);
            }
            catch (Exception ex)
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
                return View();
            }
        }

        // GET: StudentsInEventController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            return View();
        }

        // POST: StudentsInEventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: StudentsInEventController/Delete/5
        public async Task<ActionResult> Delete(Guid id,Guid studentid)
        {
            try
            {
                StudentsParticipatingInEvent participatingInEvent = _context.StudentsParticipatingInEvents.Where(s => s.StudentId.Equals(studentid)
                      & s.SportDisciplinesInEventId.Equals(id)).SingleOrDefault();

                if (participatingInEvent != null)
                {
                    _context.StudentsParticipatingInEvents.Remove(participatingInEvent);
                    await _context.SaveChangesAsync();
                }

                ViewBag.Success = "Student removed from event successfully!";
                TempData["Success"] = "Student removed from event successfully!";
            }
            catch (Exception ex) 
            {
                ViewBag.Failed = "An error occured!";
                TempData["Failed"] = "An error occured!";
            }
            return RedirectToAction(nameof(Index), id);
        }

        // POST: StudentsInEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                return View();
            }
        }
    }
}