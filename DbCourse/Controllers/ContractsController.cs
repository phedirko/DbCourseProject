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
    public class ContractsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContractsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        
        public async Task<IActionResult> Index(string sumFrom, string sumTo)
        {
            var Contracts = from c in _context.Contracts
                            select c;
            

            if (!String.IsNullOrEmpty(sumFrom) &&  !String.IsNullOrEmpty(sumTo))
            {
                double fr = Convert.ToDouble(sumFrom);
                double to = Convert.ToDouble(sumTo);

                Contracts = from c in _context.Contracts
                                where c.Summ > fr && c.Summ < to
                                select c;
            }


            

            //return View(await _context.Contracts.ToListAsync());
            return View(await Contracts.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Id");
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,DateOfReg,ManagerId,Months,Percentage,Summ")] Contract contract)
        {
            if (ModelState.IsValid)
            {

                //Bondariev'll kill me
                double mp = (Math.Pow(contract.Percentage / 100 + 1, (double)contract.Months / 12) * contract.Summ) / 12;

                //contract.MonthPayment = Math.Pow(1 + contract.Percentage*0.01, contract.Months/12);
                //contract.MonthPayment = contract.MonthPayment*contract.Summ;
                //contract.MonthPayment = contract.MonthPayment/contract.Months;

                contract.MonthPayment = mp;

                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", contract.ClientId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Id", contract.ManagerId);
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", contract.ClientId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Id", contract.ManagerId);
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,DateOfReg,ManagerId,MonthPayment,Months,Percentage,Summ")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", contract.ClientId);
            ViewData["ManagerId"] = new SelectList(_context.Managers, "Id", "Id", contract.ManagerId);
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contracts.SingleOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contract = await _context.Contracts.SingleOrDefaultAsync(m => m.Id == id);
            _context.Contracts.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ContractExists(int id)
        {
            return _context.Contracts.Any(e => e.Id == id);
        }
    }
}
