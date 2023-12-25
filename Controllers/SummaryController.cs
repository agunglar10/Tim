using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PekerjaLisensi.Data;

namespace PekerjaLisensi.Controllers
{
    public class SummaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SummaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dataReportSummary = await _context.lisensi
                                    .GroupJoin(
                                        _context.data_lisensi,
                                        lisensi => lisensi.Id,
                                        dataLisensi => dataLisensi.Lisensi,
                                        (lisensi, dataLisensiGroup) => new
                                        {
                                            NamaLisensi = lisensi.NamaLisensi,
                                            JenisLisensi = lisensi.JenisLisensi,
                                            JumlahLisensiTerpakai = dataLisensiGroup.Count(),
                                            JumlahLisensiTerpakaiNonKpi = dataLisensiGroup.Count(dl => !dl.DataPekerja.Nopek.StartsWith("2342"))
                                        })
                                    .ToListAsync();
            return View(dataReportSummary);
        }

    }
}
