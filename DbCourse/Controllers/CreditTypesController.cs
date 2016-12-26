using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DbCourse.Data;
using DbCourse.Models;

namespace DbCourse.Controllers
{
    public class CreditTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditTypesController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: CreditTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CreditType.ToListAsync());
        }

        // GET: CreditTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditType = await _context.CreditType.SingleOrDefaultAsync(m => m.Id == id);
            if (creditType == null)
            {
                return NotFound();
            }

            return View(creditType);
        }

        // GET: CreditTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CreditTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MaxMonth,MaxPercentage,MaxSum,MinMonth,MinPercentage,MinSumm,Name")] CreditType creditType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(creditType);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(creditType);
        }

        // GET: CreditTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditType = await _context.CreditType.SingleOrDefaultAsync(m => m.Id == id);
            if (creditType == null)
            {
                return NotFound();
            }
            return View(creditType);
        }

        // POST: CreditTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MaxMonth,MaxPercentage,MaxSum,MinMonth,MinPercentage,MinSumm,Name")] CreditType creditType)
        {
            if (id != creditType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(creditType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CreditTypeExists(creditType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(creditType);
        }

        // GET: CreditTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var creditType = await _context.CreditType.SingleOrDefaultAsync(m => m.Id == id);
            if (creditType == null)
            {
                return NotFound();
            }

            return View(creditType);
        }

        // POST: CreditTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var creditType = await _context.CreditType.SingleOrDefaultAsync(m => m.Id == id);
            _context.CreditType.Remove(creditType);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool CreditTypeExists(int id)
        {
            return _context.CreditType.Any(e => e.Id == id);
        }
    }
}
