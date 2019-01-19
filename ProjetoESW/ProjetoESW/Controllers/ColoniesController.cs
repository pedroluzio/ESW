using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models.Colonies;

namespace ProjetoESW.Controllers
{
    public class ColoniesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ColoniesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Colonies
        public async Task<IActionResult> Index()
        {
            return View(await _context.Colony.ToListAsync());
        }

        // GET: Colonies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colony = await _context.Colony
                .FirstOrDefaultAsync(m => m.ID == id);
            if (colony == null)
            {
                return NotFound();
            }

            return View(colony);
        }

        // GET: Colonies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Colonies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,Location")] Colony colony)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colony);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colony);
        }

        
        // POST: Colonies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var colony = await _context.Colony.FindAsync(id);
            _context.Colony.Remove(colony);
            await _context.SaveChangesAsync();
            return Accepted();
        }


        private bool ColonyExists(int id)
        {
            return _context.Colony.Any(e => e.ID == id);
        }
    }
}
