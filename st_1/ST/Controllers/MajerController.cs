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
    public class MajerController : Controller
    {
        private readonly studentContext _context;

        public MajerController(studentContext context)
        {
            _context = context;
        }

        // GET: Majer
        public async Task<IActionResult> Index()
        {
            return View(await _context.Majer.ToListAsync());
        }

        // GET: Majer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majer = await _context.Majer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (majer == null)
            {
                return NotFound();
            }

            return View(majer);
        }

        // GET: Majer/Create
        public IActionResult Create()
        {
            //int maxID = _context.Majer.Max(p => p.Id);
            //ViewBag.idMajer = maxID + 1;

            return View();
        }

        // POST: Majer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Majer majer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(majer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(majer);
        }

        // GET: Majer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majer = await _context.Majer.FindAsync(id);
            if (majer == null)
            {
                return NotFound();
            }
            return View(majer);
        }

        // POST: Majer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Majer majer)
        {
            if (id != majer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(majer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MajerExists(majer.Id))
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
            return View(majer);
        }

        // GET: Majer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var majer = await _context.Majer
                .FirstOrDefaultAsync(m => m.Id == id);
            if (majer == null)
            {
                return NotFound();
            }

            return View(majer);
        }

        // POST: Majer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var majer = await _context.Majer.FindAsync(id);
            _context.Majer.Remove(majer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MajerExists(int id)
        {
            return _context.Majer.Any(e => e.Id == id);
        }
    }
}
