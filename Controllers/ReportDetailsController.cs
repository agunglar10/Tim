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
    public class ReportDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ReportDetails
        public async Task<IActionResult> Index()
        {
            var dataReportDetails = await _context.data_pekerja
                                .Select(x => new
                                {
                                    Nama = x.Nama,
                                    Nopek = x.Nopek,
                                    Posisi = x.Posisi,

                                    JenisKaryawan = x.StatusKaryawan.StartsWith("1") ? "Aktif" : "Tidak Aktif"
                                })
                                .ToListAsync();

            return View(dataReportDetails);
        }


        // GET: ReportDetails/Create
        public IActionResult Create()
        {
            return View();
        }


        // GET: ReportDetails/SearchByNopek?searchTerm=12345
        public async Task<IActionResult> SearchByNopek(string searchTerm)
        {
            // Implementasi pencarian berdasarkan Nopek
            var dataReportDetailsQuery = _context.data_pekerja
                .Select(x => new
                {
                    Nama = x.Nama,
                    Nopek = x.Nopek,
                    Posisi = x.Posisi,
                    JenisKaryawan = x.StatusKaryawan.StartsWith("1") ? "Aktif" : "Tidak Aktif"
                });

            if (!string.IsNullOrEmpty(searchTerm))
            {
                dataReportDetailsQuery = dataReportDetailsQuery.Where(x => x.Nopek.Contains(searchTerm));
            }

            var dataReportDetails = await dataReportDetailsQuery.ToListAsync();

            // Kembalikan hasil pencarian ke laporan detail
            return View("Index", dataReportDetails);
        }



    }
}
