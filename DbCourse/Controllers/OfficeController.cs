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

        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Offices.ToListAsync());
        //}


        [HttpGet]
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            //ViewData["OfficeNSortParm"] = String.IsNullOrEmpty(sortOrder) ? "officeN_desc" : "";
            ViewData["OfficeNSortParm"] = sortOrder == "OfficeN" ? "OfficeN_desc" : "OfficeN";
            //ViewData["PassportSortParm"] = sortOrder == "Passport" ? "passport_desc" : "Passport";

            var offices = from s in _context.Offices
                          select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                offices = offices.Where(s => s.Address.Contains(searchString)
                                       || s.PhoneNumber.Contains(searchString));
            }
            
            switch (sortOrder)
            {
                case "OfficeN_desc":
                    offices = offices.OrderBy(s => s.OfficeNumber);
                    break;
                case "OfficeN":
                    offices = offices.OrderByDescending(s => s.OfficeNumber);
                    break;
                //case "passport_desc":
                //    clients = clients.OrderByDescending(s => s.Passport);
                //    break;
                default:
                    offices = offices.OrderByDescending(s => s.OfficeNumber);
                    break;
            }
            return View(await offices.AsNoTracking().ToListAsync());
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