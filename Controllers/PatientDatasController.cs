using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WNS_DEMOPROJECT.Data;
using WNS_DEMOPROJECT.Models;

namespace WNS_DEMOPROJECT.Controllers
{
    public class PatientDatasController : Controller
    {
        private readonly WNS_DEMOPROJECTContext _context;

        public PatientDatasController(WNS_DEMOPROJECTContext context)
        {
            _context = context;
        }

        // GET: PatientDatas
        public async Task<IActionResult> Index()
        {
        
           
                IQueryable<string>
          assumpquery = from m in _context.PatientDatas select m.assumptions;
                var assumptions = assumpquery.Distinct().Count();
         
            var data = await _context.PatientDatas.ToListAsync();
                return View(data);
        }

        // GET: PatientDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientDatas
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientData == null)
            {
                return NotFound();
            }

            return View(patientData);
        }

        // GET: PatientDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PatientDatas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,assumptions,data,year")] PatientData patientData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patientData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(patientData);
        }

        // GET: PatientDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientDatas.FindAsync(id);
            if (patientData == null)
            {
                return NotFound();
            }
            return View(patientData);
        }
        [HttpPost]
        public IActionResult Save(List<PatientData> pdt)
        {
            return Ok("success");
        }

        // POST: PatientDatas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,assumptions,data,year")] PatientData patientData)
        {
            if (id != patientData.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(patientData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PatientDataExists(patientData.id))
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
            return View(patientData);
        }

        // GET: PatientDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patientData = await _context.PatientDatas
                .FirstOrDefaultAsync(m => m.id == id);
            if (patientData == null)
            {
                return NotFound();
            }

            return View(patientData);
        }

        // POST: PatientDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patientData = await _context.PatientDatas.FindAsync(id);
            _context.PatientDatas.Remove(patientData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PatientDataExists(int id)
        {
            return _context.PatientDatas.Any(e => e.id == id);
        }
    }
}
