using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoESW.Data;
using ProjetoESW.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET
        [HttpGet]
        [Authorize(Roles="Administrator")]
        public IActionResult Index()
        {
            ChangeRoleModel model = new ChangeRoleModel();
            model.Roles = new List<IdentityRole>(_context.Roles.ToList());
            model.Users = new List<User>(_context.Users.ToList());
            return View("ChangeRole", model);
        }
    }
}
