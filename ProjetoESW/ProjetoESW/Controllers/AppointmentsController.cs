using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models.Animals;

namespace ProjetoESW.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointments
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Appointment.Include(a => a.Animal).Include(a => a.Colony);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Appointments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Animal)
                .Include(a => a.Colony)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // GET: Appointments/Create
        public IActionResult Create()
        {
            ViewData["AnimalID"] = new SelectList(_context.Animal, "ID", "ID");
            ViewData["ColonyID"] = new SelectList(_context.Colony, "ID", "ID");
            return View();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Date,Note,AnimalID,OVH,ColonyID")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AnimalID"] = new SelectList(_context.Animal, "ID", "ID", appointment.AnimalID);
            ViewData["ColonyID"] = new SelectList(_context.Colony, "ID", "ID", appointment.ColonyID);
            return View(appointment);
        }

        // GET: Appointments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["AnimalID"] = new SelectList(_context.Animal, "ID", "ID", appointment.AnimalID);
            ViewData["ColonyID"] = new SelectList(_context.Colony, "ID", "ID", appointment.ColonyID);
            return View(appointment);
        }

        // POST: Appointments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Date,Note,AnimalID,OVH,ColonyID")] Appointment appointment)
        {
            if (id != appointment.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.ID))
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
            ViewData["AnimalID"] = new SelectList(_context.Animal, "ID", "ID", appointment.AnimalID);
            ViewData["ColonyID"] = new SelectList(_context.Colony, "ID", "ID", appointment.ColonyID);
            return View(appointment);
        }

        [HttpPost]
        public async Task<IActionResult> MyCreate(string Date, string Appoint, int Colony)
        {
            Appointment appointment = new Appointment() {Date = Convert.ToDateTime(Date), Note = Appoint, ColonyID = Colony};
            _context.Add(appointment);
            await _context.SaveChangesAsync();
            return Accepted();

        }

        // POST: Appointments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            _context.Appointment.Remove(appointment);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.ID == id);
        }
    }
}
