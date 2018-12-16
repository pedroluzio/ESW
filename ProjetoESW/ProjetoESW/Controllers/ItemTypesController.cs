using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models.Stock;

namespace ProjetoESW.Controllers
{
    public class ItemTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.ItemType.Include(i => i.Items).ThenInclude(m => m.Movements).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var itemType = await _context.ItemType.Include(i => i.Items).ThenInclude(m => m.Movements)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (itemType == null)
            {
                return NotFound();
            }

            return View(itemType);
        }

        /// <summary>My own create.</summary>
        /// <param name="Description">The description.</param>
        /// <param name="SafetyLimit">The safety limit.</param>
        [HttpPost]
        public async Task<IActionResult> MyCreate(string Description, decimal SafetyLimit)
        {
            ItemType itemType = new ItemType(Description,SafetyLimit);
            _context.Add(itemType);
            await _context.SaveChangesAsync();
            return Accepted();

        }

        public async Task<IActionResult> Delete(int id)
        {
            var itemType = await _context.ItemType.FindAsync(id);
            _context.ItemType.Remove(itemType);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        private bool ItemTypeExists(int id)
        {
            return _context.ItemType.Any(e => e.ID == id);
        }
    }
}
