using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace FacebookLogin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult FacebookLogin()
        {
            var authProperties = new AuthenticationProperties
            {
                RedirectUri = Url.Action("Index", "Home")
            };
            return Challenge(authProperties, "Facebook");
        }
    }
}