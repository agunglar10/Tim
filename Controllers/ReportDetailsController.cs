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

        // GET: ReportDetails
        public async Task<IActionResult> Index()
        {
            return View();
        }

      
        // GET: ReportDetails/Create
        public IActionResult Create()
        {
            return View();
        }

       
    }
}
