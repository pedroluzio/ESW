using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoESW.Data;
using ProjetoESW.Models;
using ProjetoESW.Models.Stock;

namespace ProjetoESW.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id.Length==0)
            {
                return NotFound();
            }

            var item = await _context.Users.Include(u => u.UserRoles).ThenInclude(ur => ur.Role).FirstOrDefaultAsync(m => m.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            ViewData["Roles"] = new SelectList(_context.Roles.OrderBy(role => role.Name), "Id", "Name");

            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(string UserID, string RoleID)
        {
            ApplicationUserRole item = new ApplicationUserRole() { RoleId = RoleID, UserId = UserID };
            _context.UserRoles.Add(item);
            //_context.Add(item);
            await _context.SaveChangesAsync();
            return Accepted();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveRole(string UserID, string RoleID)
        {
            ApplicationUserRole item = new ApplicationUserRole() { RoleId = RoleID, UserId = UserID };
            _context.Remove(item);
            await _context.SaveChangesAsync();
            return Accepted();
        }

    }
}