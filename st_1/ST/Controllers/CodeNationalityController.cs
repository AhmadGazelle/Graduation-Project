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
    public class CodeNationalityController : Controller
    {
        private readonly studentContext _context;

        public CodeNationalityController(studentContext context)
        {
            _context = context;
        }

        // GET: CodeNationality
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeNationalities.ToListAsync());
        }

        // GET: CodeNationality/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeNationality = await _context.CodeNationalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeNationality == null)
            {
                return NotFound();
            }

            return View(codeNationality);
        }

        // GET: CodeNationality/Create
        public IActionResult Create()
        {
            int maxID = _context.CodeNationalities.Max(p => p.Id);
            ViewBag.idCodeNationalities = maxID + 1;

            return View();
        }

        // POST: CodeNationality/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameAr,NameEn")] CodeNationality codeNationality)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeNationality);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeNationality);
        }

        // GET: CodeNationality/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeNationality = await _context.CodeNationalities.FindAsync(id);
            if (codeNationality == null)
            {
                return NotFound();
            }
            return View(codeNationality);
        }

        // POST: CodeNationality/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameAr,NameEn")] CodeNationality codeNationality)
        {
            if (id != codeNationality.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeNationality);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeNationalityExists(codeNationality.Id))
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
            return View(codeNationality);
        }

        // GET: CodeNationality/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeNationality = await _context.CodeNationalities
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeNationality == null)
            {
                return NotFound();
            }

            return View(codeNationality);
        }

        // POST: CodeNationality/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeNationality = await _context.CodeNationalities.FindAsync(id);
            _context.CodeNationalities.Remove(codeNationality);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeNationalityExists(int id)
        {
            return _context.CodeNationalities.Any(e => e.Id == id);
        }
    }
}
