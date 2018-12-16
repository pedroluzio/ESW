using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ProjetoESW.Models;
using System.Diagnostics;
using System.Linq;

namespace ProjetoESW.Controllers
{

    public class HomeController : Controller
    {

        /// <summary>Indexes this instance.</summary>
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
