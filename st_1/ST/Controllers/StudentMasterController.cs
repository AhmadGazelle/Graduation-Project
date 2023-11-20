using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ST.Models;

namespace ST.Controllers
{
    public class StudentMasterController : Controller
    {
        private readonly studentContext _context;

        public StudentMasterController(studentContext context)
        {
            _context = context;
        }

        // GET: StudentMaster
        public async Task<IActionResult> Index()
        {
            var studentContext = _context.StudentMasters.Include(s => s.NationalityNavigation);
            return View(await studentContext.ToListAsync());
        }

        // GET: StudentMaster/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMaster = await _context.StudentMasters
                .Include(s => s.NationalityNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            return View(studentMaster);
        }

        // GET: StudentMaster/Create
        public IActionResult Create()
        {
            int maxID = _context.StudentMasters.Max(p => p.Id);
            ViewBag.idStudentMasters = maxID + 1;

            ViewData["Nationality"] = new SelectList(_context.CodeNationalities, "Id", "NameAr");
            ViewData["College"] = new SelectList(_context.CollegeName, "Id", "CollegeName1");
            ViewData["university"] = new SelectList(_context.Universities, "Id", "NameAr");
            ViewData["sex"] = new SelectList(_context.GenderType, "Id", "GenderType1");
            ViewData["Major"] = new SelectList(_context.Majer, "Id", "Name");

            return View();
        }

        // POST: StudentMaster/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BirthDate,University,College,Major,Sex,Nationality")] StudentMaster studentMaster)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentMaster);
                await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
                return RedirectToAction("Create", "User");
                //return RedirectToAction(nameof(User/Create));
            }
            ViewData["Nationality"] = new SelectList(_context.CodeNationalities, "Id", "Id", studentMaster.Nationality);
            return View(studentMaster);
        }

        // GET: StudentMaster/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMaster = await _context.StudentMasters.FindAsync(id);
            if (studentMaster == null)
            {
                return NotFound();
            }
            ViewData["Nationality"] = new SelectList(_context.CodeNationalities, "Id", "Id", studentMaster.Nationality);
            return View(studentMaster);
        }

        // POST: StudentMaster/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BirthDate,University,College,Major,Sex,Nationality")] StudentMaster studentMaster)
        {
            if (id != studentMaster.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentMasterExists(studentMaster.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Nationality"] = new SelectList(_context.CodeNationalities, "Id", "Id", studentMaster.Nationality);
            return View(studentMaster);
        }

        // GET: StudentMaster/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var studentMaster = await _context.StudentMasters
                .Include(s => s.NationalityNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentMaster == null)
            {
                return NotFound();
            }

            return View(studentMaster);
        }

        // POST: StudentMaster/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var studentMaster = await _context.StudentMasters.FindAsync(id);
            _context.StudentMasters.Remove(studentMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentMasterExists(int id)
        {
            return _context.StudentMasters.Any(e => e.Id == id);
        }
        public IActionResult Admin()
        {
            return View();
        }

    }
}
