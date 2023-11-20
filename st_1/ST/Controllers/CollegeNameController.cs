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
    public class CollegeNameController : Controller
    {
        private readonly studentContext _context;

        public CollegeNameController(studentContext context)
        {
            _context = context;
        }

        // GET: CollegeName
        public async Task<IActionResult> Index()
        {
            return View(await _context.CollegeName.ToListAsync());
        }

        // GET: CollegeName/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeName = await _context.CollegeName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collegeName == null)
            {
                return NotFound();
            }

            return View(collegeName);
        }

        // GET: CollegeName/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CollegeName/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CollegeName1")] CollegeName collegeName)
        {
            if (ModelState.IsValid)
            {
                _context.Add(collegeName);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(collegeName);
        }

        // GET: CollegeName/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeName = await _context.CollegeName.FindAsync(id);
            if (collegeName == null)
            {
                return NotFound();
            }
            return View(collegeName);
        }

        // POST: CollegeName/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CollegeName1")] CollegeName collegeName)
        {
            if (id != collegeName.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(collegeName);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CollegeNameExists(collegeName.Id))
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
            return View(collegeName);
        }

        // GET: CollegeName/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var collegeName = await _context.CollegeName
                .FirstOrDefaultAsync(m => m.Id == id);
            if (collegeName == null)
            {
                return NotFound();
            }

            return View(collegeName);
        }

        // POST: CollegeName/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var collegeName = await _context.CollegeName.FindAsync(id);
            _context.CollegeName.Remove(collegeName);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CollegeNameExists(int id)
        {
            return _context.CollegeName.Any(e => e.Id == id);
        }
    }
}
