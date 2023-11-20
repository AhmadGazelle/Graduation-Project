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
    public class CodeCompanyController : Controller
    {
        private readonly studentContext _context;

        public CodeCompanyController(studentContext context)
        {
            _context = context;
        }

        // GET: CodeCompany
        public async Task<IActionResult> Index()
        {
            return View(await _context.CodeCompanies.ToListAsync());
        }

        // GET: CodeCompany/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeCompany = await _context.CodeCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeCompany == null)
            {
                return NotFound();
            }

            return View(codeCompany);
        }

        // GET: CodeCompany/Create
        public IActionResult Create()
        {
            int maxID = _context.CodeCompanies.Max(p => p.Id);
            ViewBag.idCodeCompanies = maxID + 1;

            return View();
        }

        // POST: CodeCompany/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NameAr,NameEn")] CodeCompany codeCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(codeCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(codeCompany);
        }

        // GET: CodeCompany/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeCompany = await _context.CodeCompanies.FindAsync(id);
            if (codeCompany == null)
            {
                return NotFound();
            }
            return View(codeCompany);
        }

        // POST: CodeCompany/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NameAr,NameEn")] CodeCompany codeCompany)
        {
            if (id != codeCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(codeCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CodeCompanyExists(codeCompany.Id))
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
            return View(codeCompany);
        }

        // GET: CodeCompany/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var codeCompany = await _context.CodeCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (codeCompany == null)
            {
                return NotFound();
            }

            return View(codeCompany);
        }

        // POST: CodeCompany/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var codeCompany = await _context.CodeCompanies.FindAsync(id);
            _context.CodeCompanies.Remove(codeCompany);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CodeCompanyExists(int id)
        {
            return _context.CodeCompanies.Any(e => e.Id == id);
        }
    }
}
