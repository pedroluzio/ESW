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
    public class ItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Item.Include(i => i.ItemType).Include(m => m.Movements);
            return View(await applicationDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var item = await _context.Item
                .Include(i => i.ItemType)
                .Include(m => m.Movements)
                .FirstOrDefaultAsync(m => m.ID == id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        public IActionResult Create()
        {
            ViewData["ItemTypeID"] = new SelectList(_context.ItemType.OrderBy(type => type.Description), "ID", "Description");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ItemTypeID,Descricao,Quantidade")] Item item)
        {
            if (ModelState.IsValid)
            {
                _context.Add(item);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ItemTypeID"] = new SelectList(_context.ItemType, "ID", "Description", item.ItemTypeID);
            return View(item);
        }

        /// <summary>My own create.</summary>
        /// <param name="ItemTypeID">The item type identifier.</param>
        /// <param name="Description">The description.</param>
        /// <param name="Quantity">The quantity.</param>
        [HttpPost]
        public async Task<IActionResult> MyCreate(int ItemTypeID, string Description, decimal Quantity)
        {
            Item item = new Item
            {
                Descricao = Description, ID = 0, ItemTypeID = ItemTypeID, ItemType = null, Movements = null,
                Quantidade = Quantity
            };
            _context.Add(item);
            await _context.SaveChangesAsync();
            return Accepted();

        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Item.FindAsync(id);
            _context.Item.Remove(item);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        private bool ItemExists(int id)
        {
            return _context.Item.Any(e => e.ID == id);
        }
    }
}
