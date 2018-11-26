using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoESW.Models;

namespace ProjetoESW.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            if(User.Identity.IsAuthenticated)
                return View();

            return Redirect("Identity/Account/Login");

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
