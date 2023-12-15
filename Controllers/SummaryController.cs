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
    public class SummaryController : Controller
    {


        // GET: Summary
        public async Task<IActionResult> Index()
        {
            return View();
        }

        //// GET: Summary/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var summaryModel = await _context.SummaryModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (summaryModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(summaryModel);
        //}

        // GET: Summary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Summary/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Lisensi,JumlahLisensi,LisensiTerpakai,LisensiTerpakaiNonKPI")] SummaryModel summaryModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(summaryModel);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(summaryModel);
        //}

        // GET: Summary/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var summaryModel = await _context.SummaryModel.FindAsync(id);
        //    if (summaryModel == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(summaryModel);
        //}

        // POST: Summary/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Lisensi,JumlahLisensi,LisensiTerpakai,LisensiTerpakaiNonKPI")] SummaryModel summaryModel)
        //{
        //    if (id != summaryModel.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(summaryModel);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!SummaryModelExists(summaryModel.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(summaryModel);
        //}

        // GET: Summary/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var summaryModel = await _context.SummaryModel
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (summaryModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(summaryModel);
        //}

        // POST: Summary/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var summaryModel = await _context.SummaryModel.FindAsync(id);
        //    if (summaryModel != null)
        //    {
        //        _context.SummaryModel.Remove(summaryModel);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool SummaryModelExists(int id)
        //{
        //    return _context.SummaryModel.Any(e => e.Id == id);
        //}
    }
}
