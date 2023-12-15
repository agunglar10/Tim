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
            return View(await _context.DataPekerja.ToListAsync());
        }


        //private bool DataPekerjaModelExists(int id)
        //{
        //    return _context.DataPekerjaModel.Any(e => e.Id == id);
        //}
    }
}
