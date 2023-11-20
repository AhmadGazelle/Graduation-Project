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
    public class CodeUniverstyController : Controller
    {
        private readonly studentContext _context;

        public CodeUniverstyController(studentContext context)
        {
            _context = context;
        }

        // GET: CodeUniversty
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeUniversties.ToListAsync());
        }

        // GET: CodeUniversty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeUniversty = await _context.CodeUniversties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeUniversty == null)
            {
                return NotFound();
            }

            return View(codeUniversty);
        }

        // GET: CodeUniversty/Create
        public IActionResult Create()
        {
            int maxID = _context.CodeUniversties.Max(p => p.Id);
            ViewBag.idCodeUniversties = maxID + 1;

            return View();
        }

        // POST: CodeUniversty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameAr,NameEn")] CodeUniversty codeUniversty)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeUniversty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeUniversty);
        }

        // GET: CodeUniversty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeUniversty = await _context.CodeUniversties.FindAsync(id);
            if (codeUniversty == null)
            {
                return NotFound();
            }
            return View(codeUniversty);
        }

        // POST: CodeUniversty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameAr,NameEn")] CodeUniversty codeUniversty)
        {
            if (id != codeUniversty.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeUniversty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeUniverstyExists(codeUniversty.Id))
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
            return View(codeUniversty);
        }

        // GET: CodeUniversty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeUniversty = await _context.CodeUniversties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeUniversty == null)
            {
                return NotFound();
            }

            return View(codeUniversty);
        }

        // POST: CodeUniversty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeUniversty = await _context.CodeUniversties.FindAsync(id);
            _context.CodeUniversties.Remove(codeUniversty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeUniverstyExists(int id)
        {
            return _context.CodeUniversties.Any(e => e.Id == id);
        }
    }
}
