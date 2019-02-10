using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoESW.Models;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models.Stock;

namespace ProjetoESW.Controllers
{

    public class HomeController : Controller
    {

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>Indexes this instance.</summary>
        public async Task<IActionResult> Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                var itemType = await _context.ItemType.Include(i => i.Items).ThenInclude(m => m.Movements).ToListAsync();
                var animals = await _context.Animal.ToListAsync();
                int numAnimals = _context.Animal.Count();
                int colonies = _context.Colony.Count();
                var appointments = await _context.Appointment.Include(a => a.Colony).Include(a => a.Animal).ToListAsync();

                ModelIndex modelIndex = new ModelIndex() {ItemTypes = itemType, Animals =animals,NumAnimals = numAnimals, Colonies = colonies, Appointments = appointments};

                return View(modelIndex);
            }

            return Redirect("Identity/Account/Login");

        }


        /// <summary>Indexes this instance.</summary>
        public async Task<IActionResult> SMS()
        {
                return View();
            
                

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
