using CsrfMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsrfMvc.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private Vault vault = new Vault();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";
            ViewBag.Balance = vault.GetBalance(HttpContext.User.Identity.Name);
            return View();
        }
    }
}
