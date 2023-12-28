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
            return View(await _context.lisensi.ToListAsync());

        }

       
        public IActionResult Create()
        {
            ViewBag.ListLisensi = _context.lisensi
                                .Select(l => l.NamaLisensi)
                                .Distinct()
                                .ToList()
                                .Select(s => Char.ToUpper(s[0]) + s.Substring(1))
                                .ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Lisensi lisensi, string NamaLisensiLainnya)
        {

            if (!string.IsNullOrWhiteSpace(NamaLisensiLainnya))
            {
                lisensi.NamaLisensi = NamaLisensiLainnya;
            }

            _context.lisensi.Add(lisensi);

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

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lisensi = await _context.lisensi.FindAsync(id);
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

        private bool LisensiExists(int id)
        {
            return _context.lisensi.Any(e => e.Id == id);
        }

        // GET: DataLisensi/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lisensi = await _context.lisensi
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
            var lisensi = await _context.lisensi.FindAsync(id);
            if (lisensi == null)
            {
                return NotFound();
            }

            _context.lisensi.Remove(lisensi);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }




    }
}
