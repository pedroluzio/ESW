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
    public class SpeciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SpeciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Specie.Include(b => b.Breeds).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specie = await _context.Specie
                .FirstOrDefaultAsync(m => m.ID == id);
            if (specie == null)
            {
                return NotFound();
            }

            return View(specie);
        }
        
        /// <summary>My own create.</summary>
        /// <param name="name">The Specie name.</param>
        [HttpPost]
        public async Task<IActionResult> MyCreate(string name)
        {
            if (SpecieExistsName(name))
                return NotFound();
            _context.Add(new Specie(){Name = name,ID = 0,Breeds = null});
            await _context.SaveChangesAsync();
            return Accepted();
            
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var specie = await _context.Specie.FindAsync(id);
            _context.Specie.Remove(specie);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        private bool SpecieExists(int id)
        {
            return _context.Specie.Any(e => e.ID == id);
        }

        private bool SpecieExistsName(string name)
        {
            return _context.Specie.Any(e => e.Name.ToUpper().Equals(name.ToUpper()));
        }
    }
}
