using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PatientCardsITC.DBContext;

namespace PatientCardsITC.Models
{
    public class HistoriesController : Controller
    {
        private readonly ApplicationContext _context;

        public HistoriesController(ApplicationContext context)
        {
            _context = context;
        }

        // GET: Histories
        public async Task<IActionResult> Index()
        {
            var applicationContext = _context.Histories.Include(h => h.Doctor).Include(h => h.Patient).Include(h => h.Position).OrderByDescending( m => m.VisitDate);
            return View(await applicationContext.ToListAsync());
        }

        // GET: Histories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.Doctor)
                .Include(h => h.Patient)
                .Include(h => h.Position)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // GET: Histories/Create
        public IActionResult Create()
        {
            int selectedIndex = _context.Positions.First().PositionId;
            ViewData["DoctorId"] = new SelectList(_context.Doctors.Where(c => c.PositionId == selectedIndex).OrderBy( c => c.FIO), "DoctorId", "FIO");
            ViewData["PatientId"] = new SelectList(_context.Patients.OrderBy(c => c.FIO), "PatientId", "FIO");
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", selectedIndex);
            return View();
        }

        // POST: Histories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HistoryId,PatientId,PositionId,DoctorId,Diagnos,Complain,VisitDate")] History history)
        {
            if (ModelState.IsValid)
            {
                _context.Add(history);
                await _context.SaveChangesAsync();
                return PartialView("Success");
                //return RedirectToAction(nameof(Index));
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "FIO", history.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FIO", history.PatientId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", history.PositionId);
            return PartialView(history);
        }

        // GET: Histories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories.FindAsync(id);
            if (history == null)
            {
                return NotFound();
            }
            ViewData["DoctorId"] = new SelectList(_context.Doctors.OrderBy(c => c.FIO), "DoctorId", "FIO", history.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients.OrderBy(c => c.FIO), "PatientId", "FIO", history.PatientId);
            ViewData["PositionId"] = new SelectList(_context.Positions.OrderBy(c => c.PositionName), "PositionId", "PositionName", history.PositionId);
            return View(history);
        }

        // POST: Histories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HistoryId,PatientId,PositionId,DoctorId,Diagnos,Complain,VisitDate")] History history)
        {
            if (id != history.HistoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(history);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoryExists(history.HistoryId))
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
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "DoctorId", "FIO", history.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "FIO", history.PatientId);
            ViewData["PositionId"] = new SelectList(_context.Positions, "PositionId", "PositionName", history.PositionId);
            return View(history);
        }

        // GET: Histories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var history = await _context.Histories
                .Include(h => h.Doctor)
                .Include(h => h.Patient)
                .Include(h => h.Position)
                .FirstOrDefaultAsync(m => m.HistoryId == id);
            if (history == null)
            {
                return NotFound();
            }

            return View(history);
        }

        // POST: Histories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var history = await _context.Histories.FindAsync(id);
            _context.Histories.Remove(history);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoryExists(int id)
        {
            return _context.Histories.Any(e => e.HistoryId == id);
        }

        public ActionResult GetHistories(string id, string IIN)
        {
            IEnumerable<History> Histories;

            if (IIN != null){
                Histories = _context.Histories
   .Include(h => h.Doctor)
   .Include(h => h.Patient)
   .Include(h => h.Position)
   .Where(iin => iin.Patient.IIN.Contains(IIN))
   .OrderByDescending(m => m.VisitDate);
            }
            else
            {
                if (id == null)
                {
                    Histories = _context.Histories
                        .Include(h => h.Doctor)
                        .Include(h => h.Patient)
                        .Include(h => h.Position)
                        .OrderByDescending(m => m.VisitDate);
                }
                else
                {
                    Histories = _context.Histories
                       .Include(h => h.Doctor)
                       .Include(h => h.Patient)
                       .Include(h => h.Position)
                       .Where(fio => fio.Patient.FIO.Contains(id))
                       .OrderByDescending(m => m.VisitDate);
                }
            }
            return PartialView(Histories);
        }

        // GET: Patients/Create
        public IActionResult CreatePatient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePatient([Bind("PatientId,IIN,FIO,Address,PhoneNumber")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _context.Add(patient);
                await _context.SaveChangesAsync();
                return PartialView("Success");
            }
            return View(patient);
        }

        public ActionResult GetItems(int id)
        {
            ViewData["DoctorId"] = new SelectList(_context.Doctors.Where(c => c.PositionId == id), "DoctorId", "FIO");
            return PartialView();
        }
    }
}
