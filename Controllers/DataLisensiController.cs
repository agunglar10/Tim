using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PekerjaLisensi.Data;
using PekerjaLisensi.Data.Migrations;
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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lisensi = await _context.Lisensitable.FindAsync(id);
            if (lisensi == null)
            {
                return NotFound();
            }

            return View(lisensi);
        }

        // POST: DataLisensi/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Lisensi lisensi)
        {
            if (id != lisensi.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Entry(lisensi).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LisensiExists(id))
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
            return View(lisensi);
        }

        private bool LisensiExists(int id)
        {
            return _context.Lisensitable.Any(e => e.Id == id);
        }

        // GET: DataLisensi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lisensi = await _context.Lisensitable
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lisensi == null)
            {
                return NotFound();
            }

            return View(lisensi);
        }

        // POST: DataLisensi/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lisensi = await _context.Lisensitable.FindAsync(id);
            if (lisensi == null)
            {
                return NotFound();
            }

            _context.Lisensitable.Remove(lisensi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
