using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsingJWTAuthorization.Models;

namespace UsingJWTAuthorization.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult GetUserDetails()
        {
            return new ObjectResult(new
            {
                Username = User.Identity.Name
            });
        }
    }
}
