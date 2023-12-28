using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PekerjaLisensi.Data;
using PekerjaLisensi.Models;

namespace PekerjaLisensi.Controllers
{
    public class DataPekerjaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DataPekerjaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DataPekerja
        public async Task<IActionResult> Index()
        {
            var dataPekerja = await _context.data_pekerja
                                   .Include(p => p.DataLisensis) 
                                       .ThenInclude(dl => dl.LisensiAja) 
                                   .ToListAsync();

            return View(dataPekerja);
        }

        //private bool DataPekerjaModelExists(int id)
        //{
        //    return _context.DataPekerjaModel.Any(e => e.Id == id);
        //}

        // GET: DataPekerja/TambahLisensi
        public IActionResult TambahLisensi(string nopek)
        {
            var dataPekerja = _context.data_pekerja.FirstOrDefault(dp => dp.Nopek == nopek);
            if (dataPekerja == null)
            {
                // Handle not found
                return NotFound();
            }

            var lisensiList = _context.lisensi.ToList();
            ViewBag.LisensiList = lisensiList;


            // Fetching DataLisensi records
            ViewBag.RegisteredLisensi = _context.data_lisensi
                                        .Where(dl => dl.Nopek == nopek)
                                        .Select(dl => dl.Lisensi)
                                        .ToList();
            return View(dataPekerja);
        }

        // POST: DataPekerja/TambahLisensi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TambahLisensi(DataPekerja dataPekerja, int SelectedLisensi)
        {
            var newDataLisensi = new DataLisensi
            {
                Nopek = dataPekerja.Nopek,
                Lisensi = SelectedLisensi
            };

            _context.data_lisensi.Add(newDataLisensi);

            try
            {
                // Save changes in the context
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine(ex.Message);
                return View(dataPekerja);
            }

            return RedirectToAction("Index");

        }

        public IActionResult Create()
        {
            ViewBag.ListPekerja = _context.data_pekerja
                                .ToList();

            ViewBag.ListLisensi = _context.lisensi
                                .OrderBy(l => l.NamaLisensi)
                                .ThenBy(l => l.JenisLisensi)
                                .ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DataLisensi dataLisensi)
        {

            _context.data_lisensi.Add(dataLisensi);

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

    }
}
