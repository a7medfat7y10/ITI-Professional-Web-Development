using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Task.Models;
using Task.RepoServices;

namespace Task.Controllers
{
    public class TraineesController : Controller
    {
        private readonly Day9DbContext _context;

        public ITraineeRepository TraineeRepository { get; set; }
        public TraineesController(Day9DbContext context, ITraineeRepository traineeRepository)
        {
            _context = context;
            TraineeRepository = traineeRepository;
        }

        // GET: Trainees
        public async Task<IActionResult> Index()
        {
            var day9DbContext = _context.Trainees.Include(t => t.Course).Include(t => t.Track);
            return View(await day9DbContext.ToListAsync());
        }

        // GET: Trainees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees
                .Include(t => t.Course)
                .Include(t => t.Track)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // GET: Trainees/Create
        public IActionResult Create()
        {
            ViewData["CID"] = new SelectList(_context.Courses, "CID", "CGrade");
            ViewData["TrackID"] = new SelectList(_context.Tracks, "TrackID", "TrackName");
            return View();
        }

        // POST: Trainees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,gender,Email,PhoneNum,BDate,CID,TrackID")] Trainee trainee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trainee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CID"] = new SelectList(_context.Courses, "CID", "CGrade", trainee.CID);
            ViewData["TrackID"] = new SelectList(_context.Tracks, "TrackID", "TrackName", trainee.TrackID);
            return View(trainee);
        }

        // GET: Trainees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee == null)
            {
                return NotFound();
            }
            ViewData["CID"] = new SelectList(_context.Courses, "CID", "CGrade", trainee.CID);
            ViewData["TrackID"] = new SelectList(_context.Tracks, "TrackID", "TrackName", trainee.TrackID);
            return View(trainee);
        }

        // POST: Trainees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,gender,Email,PhoneNum,BDate,CID,TrackID")] Trainee trainee)
        {
            if (id != trainee.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trainee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TraineeExists(trainee.ID))
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
            ViewData["CID"] = new SelectList(_context.Courses, "CID", "CGrade", trainee.CID);
            ViewData["TrackID"] = new SelectList(_context.Tracks, "TrackID", "TrackName", trainee.TrackID);
            return View(trainee);
        }

        // GET: Trainees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Trainees == null)
            {
                return NotFound();
            }

            var trainee = await _context.Trainees
                .Include(t => t.Course)
                .Include(t => t.Track)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (trainee == null)
            {
                return NotFound();
            }

            return View(trainee);
        }

        // POST: Trainees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Trainees == null)
            {
                return Problem("Entity set 'Day9DbContext.Trainees'  is null.");
            }
            var trainee = await _context.Trainees.FindAsync(id);
            if (trainee != null)
            {
                _context.Trainees.Remove(trainee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TraineeExists(int id)
        {
          return (_context.Trainees?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
