﻿using System;
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
            var dataLisensi = await _context.DataLisensi
                                            .Join(_context.DataPekerja,
                                                  lisensi => lisensi.Nopek,
                                                  pekerja => pekerja.Nopek,
                                                  (lisensi, pekerja) => new { Lisensi = lisensi.Lisensi })
                                            .ToListAsync();

            return View(dataLisensi);
        }

        //private bool DataPekerjaModelExists(int id)
        //{
        //    return _context.DataPekerjaModel.Any(e => e.Id == id);
        //}
        // POST: DataPekerja/TambahLisensi

        // GET: DataPekerja/TambahLisensi
        public IActionResult TambahLisensi()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TambahLisensi(DataPekerja dataPekerja)
        {
            if (ModelState.IsValid)
            {
                // Lakukan operasi tambah data ke basis data
                _context.DataPekerja.Add(dataPekerja);

                try
                {
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    // Tangani exception di sini
                    Console.WriteLine(ex.Message);
                }

                // Redirect ke action Index setelah berhasil menambahkan data
                return RedirectToAction("Index");
            }

            // Jika ModelState tidak valid, kembalikan ke view dengan model yang disertakan
            return View(dataPekerja);
        }

    }
}
