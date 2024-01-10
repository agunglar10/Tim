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
        private const int PageSize = 10; // Set the number of items per page


        public DataPekerjaController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: DataPekerja
        public async Task<IActionResult> Index(int page = 1)
        {
            var dataPekerja = await _context.data_pekerja
                .Include(p => p.DataLisensis)
                .ThenInclude(dl => dl.LisensiAja)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .ToListAsync();

            var totalItems = await _context.data_pekerja.CountAsync();
            var totalPages = (int)System.Math.Ceiling(totalItems / (double)PageSize);

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(dataPekerja);
        }

        // GET: DataPekerja
        //public async Task<IActionResult> Index()
        //{
        //    var dataPekerja = await _context.data_pekerja
        //                           .Include(p => p.DataLisensis)
        //                               .ThenInclude(dl => dl.LisensiAja)
        //                           .ToListAsync();

        //    return View(dataPekerja);
        //}

        //private bool DataPekerjaModelExists(int id)
        //{
        //    return _context.DataPekerjaModel.Any(e => e.Id == id);
        //}

        // GET: DataPekerja/TambahLisensi
        public IActionResult TambahLisensi(string id)
        {
            var dataPekerja = _context.data_pekerja.FirstOrDefault(dp => dp.Id.ToString() == id);
            if (dataPekerja == null)
            {
                // Handle not found
                return NotFound();
            }

            var lisensiList = _context.lisensi.ToList();
            ViewBag.LisensiList = lisensiList;
            // views bag berguna untuk menyimpan data atau mengirmkan ke tampilan views

            // Fetching DataLisensi records
            ViewBag.RegisteredLisensi = _context.data_lisensi
                                        .Where(dl => dl.Pekerja.ToString() == id)
                                        .Select(dl => dl.Lisensi)
                                        .ToList();
            // Tolist() digunakan untuk mengeksekusi kueri dan mengonversi hasilnya menjadi daftar
            return View(dataPekerja);
        }

        // POST: DataPekerja/TambahLisensi
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult TambahLisensi(DataPekerja dataPekerja, int SelectedLisensi)
        {
            var newDataLisensi = new DataLisensi
            {
                Pekerja = dataPekerja.Id,
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

        public async Task<IActionResult> SearchByNopek(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm))
            {
                // Handle empty search term
                return RedirectToAction("Index");
            }

            var dataPekerja = await _context.data_pekerja
                                   .Include(p => p.DataLisensis)
                                       .ThenInclude(dl => dl.LisensiAja)
                                   .Where(dp => dp.Nopek.Contains(searchTerm))
                                   .ToListAsync();

            ViewBag.SearchTerm = searchTerm;

            return View("Index", dataPekerja);
        }

        [HttpGet]
        public IActionResult DeleteAllLisensi(int id)
        {
            var dataPekerja = _context.data_pekerja
                .Include(dp => dp.DataLisensis)
                    .ThenInclude(dl => dl.LisensiAja)
                .FirstOrDefault(dp => dp.Id == id);

            if (dataPekerja == null)
            {
                return RedirectToAction("Index");
            }

            // Mengisi dropdown dengan lisensi yang dimiliki pekerja
            ViewBag.LisensiList = dataPekerja.DataLisensis
                                            .Select(dl => new SelectListItem
                                            {
                                                Value = dl.Id.ToString(),
                                                Text = $"{dl.LisensiAja.NamaLisensi} - {dl.LisensiAja.JenisLisensi}"
                                            })
                                            .ToList();

            return View(dataPekerja);
        }


        [HttpGet]
        public IActionResult DeleteAllLisensiGet(int id)
        {
            var dataPekerja = _context.data_pekerja
                .Include(dp => dp.DataLisensis)
                    .ThenInclude(dl => dl.LisensiAja)
                .FirstOrDefault(dp => dp.Id == id);

            if (dataPekerja == null)
            {
                return RedirectToAction("Index");
            }

            // Mengisi dropdown dengan lisensi yang dimiliki pekerja
            ViewBag.LisensiList = new SelectList(dataPekerja.DataLisensis
                                                .Select(dl => new SelectListItem
                                                {
                                                    Value = dl.Id.ToString(),
                                                    Text = $"{dl.LisensiAja.NamaLisensi} - {dl.LisensiAja.JenisLisensi}"
                                                }), "Value", "Text");

            return View(dataPekerja);
        }

        [HttpPost, ActionName("DeleteAllLisensi")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteAllLisensiConfirmed(int id, List<int> SelectedLisensi)
        {
            // Implementasi logika penghapusan lisensi
            var dataPekerja = _context.data_pekerja
                .Include(dp => dp.DataLisensis)
                .FirstOrDefault(dp => dp.Id == id);

            if (dataPekerja != null && SelectedLisensi != null && SelectedLisensi.Any())
            {
                foreach (var lisensiId in SelectedLisensi)
                {
                    var dataLisensi = dataPekerja.DataLisensis.FirstOrDefault(dl => dl.Id == lisensiId);

                    if (dataLisensi != null)
                    {
                        _context.data_lisensi.Remove(dataLisensi);
                    }
                }

                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        // GET: DataPekerja/EditLisensi/5
        public IActionResult EditLisensi(int id)
        {
            var dataPekerja = _context.data_pekerja
                .Include(dp => dp.DataLisensis)
                .ThenInclude(dl => dl.LisensiAja)
                .FirstOrDefault(dp => dp.Id == id);

            if (dataPekerja == null)
            {
                return RedirectToAction("Index");
            }

            // Mengisi dropdown dengan lisensi yang dimiliki pekerja
            ViewBag.LisensiList = new SelectList(dataPekerja.DataLisensis
                .Select(dl => new SelectListItem
                {
                    Value = dl.Id.ToString(),
                    Text = $"{dl.LisensiAja.NamaLisensi} - {dl.LisensiAja.JenisLisensi}"
                }), "Value", "Text");

            return View(dataPekerja);
        }

        // POST: DataPekerja/EditLisensi/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditLisensi(int id, int selectedLisensi)
        {
            var dataPekerja = _context.data_pekerja
                .Include(dp => dp.DataLisensis)
                .FirstOrDefault(dp => dp.Id == id);

            if (dataPekerja != null)
            {
                var dataLisensi = dataPekerja.DataLisensis.FirstOrDefault(dl => dl.Id == selectedLisensi);
                if (dataLisensi != null)
                {
                    // Lakukan perubahan pada data lisensi (misalnya, NamaLisensi dan JenisLisensi)
                    dataLisensi.LisensiAja.NamaLisensi = "Nama Lisensi Baru";
                    dataLisensi.LisensiAja.JenisLisensi = "Jenis Lisensi Baru";

                    
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }



    }
}




