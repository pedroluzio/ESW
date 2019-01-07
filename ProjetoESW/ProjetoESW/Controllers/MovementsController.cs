using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models.Stock;

namespace ProjetoESW.Controllers
{
    [Authorize(Roles = "Administrator, Gestor de Stocks")]
    public class MovementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MovementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>My own create.</summary>
        /// <param name="itemID">The item identifier.</param>
        /// <param name="quantity">The quantity.</param>
        [HttpPost]
        public async Task<IActionResult> MyCreate(int itemID, int quantity)
        {
            Movements movements = new Movements
            { ID = 0, Item = null, ItemID = itemID, Moment = DateTime.Now, Quantity = quantity };
            _context.Add(movements);
            await _context.SaveChangesAsync();

            return Accepted();
        }

        public async Task<IActionResult> Delete(int id)
        {
            var movements = await _context.Movements.FindAsync(id);
            _context.Movements.Remove(movements);
            await _context.SaveChangesAsync();

            return Accepted();
        }

        private bool MovementsExists(int id)
        {
            return _context.Movements.Any(e => e.ID == id);
        }
    }
}
