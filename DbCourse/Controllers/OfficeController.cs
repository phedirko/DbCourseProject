using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DbCourse.Data;
using Microsoft.EntityFrameworkCore;
using DbCourse.Models;

namespace DbCourse.Controllers
{
    public class OfficeController : Controller
    {
        public readonly ApplicationDbContext _context;

        public OfficeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Offices.ToListAsync());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,Address,PhoneNumber,OfficeNumber")]Office office)
        {
            if (ModelState.IsValid)
            {
                _context.Add(office);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(office);
        }

        public async Task<IActionResult> Details(int? Id)
        {
            var office = await _context.Offices
                .Include(m => m.Managers)
                .SingleOrDefaultAsync(m => m.Id == Id);

            return View(office);
        }
    }
}