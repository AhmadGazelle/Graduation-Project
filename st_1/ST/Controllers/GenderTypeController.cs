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
    public class GenderTypeController : Controller
    {
        private readonly studentContext _context;

        public GenderTypeController(studentContext context)
        {
            _context = context;
        }

        // GET: GenderType
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenderType.ToListAsync());
        }

        // GET: GenderType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderType = await _context.GenderType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genderType == null)
            {
                return NotFound();
            }

            return View(genderType);
        }

        // GET: GenderType/Create
        public IActionResult Create()
        {
            //int maxID = _context.GenderType.Max(p => p.Id);
            //ViewBag.idGenderType = maxID + 1;

            return View();
        }

        // POST: GenderType/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,GenderType1")] GenderType genderType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genderType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genderType);
        }

        // GET: GenderType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderType = await _context.GenderType.FindAsync(id);
            if (genderType == null)
            {
                return NotFound();
            }
            return View(genderType);
        }

        // POST: GenderType/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,GenderType1")] GenderType genderType)
        {
            if (id != genderType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genderType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderTypeExists(genderType.Id))
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
            return View(genderType);
        }

        // GET: GenderType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderType = await _context.GenderType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (genderType == null)
            {
                return NotFound();
            }

            return View(genderType);
        }

        // POST: GenderType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genderType = await _context.GenderType.FindAsync(id);
            _context.GenderType.Remove(genderType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderTypeExists(int id)
        {
            return _context.GenderType.Any(e => e.Id == id);
        }
    }
}
