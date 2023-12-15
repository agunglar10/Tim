using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PekerjaLisensi.Data;
using PekerjaLisensi.Models;

namespace PekerjaLisensi.Controllers
{
    public class DataLisensiController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataLisensiController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: DataLisensi
        public async Task<IActionResult> Index()
        {
            return View(await _context.Lisensitable.ToListAsync());

        }

       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lisensi lisensi)
        {
            if (ModelState.IsValid)
            {
 
                _context.Lisensitable.Add(lisensi);

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Tangani exception di sini
                    Console.WriteLine(ex.Message);
                }

                // Redirect to the index or another action
                return RedirectToAction("Index");
            }

            // If ModelState is not valid, return to the create view with the provided model
            return View(lisensi);
        }


    }
}
