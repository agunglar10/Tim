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
                                    JenisKaryawan = x.Nopek.StartsWith("2342") ? "Pekerja KPI" : "Pekerja Non KPI"
                                })
                                .ToListAsync();
            return View(dataReportDetails);
        }

      
        // GET: ReportDetails/Create
        public IActionResult Create()
        {
            return View();
        }

       
    }
}
