using CsrfMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CsrfMvc.Controllers
{
    public class BankAccountController : Controller
    {
        private Vault vault = new Vault();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Secure(double amount, string mode)
        {
            if ("deposit".Equals(mode, StringComparison.InvariantCultureIgnoreCase))
            {
                vault.AddToAccount(HttpContext.User.Identity.Name, secure: amount);
            }

            if ("withdraw".Equals(mode, StringComparison.InvariantCultureIgnoreCase))
            {
                vault.AddToAccount(HttpContext.User.Identity.Name, secure: -amount);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Insecure(double amount, string mode)
        {
            if ("deposit".Equals(mode, StringComparison.InvariantCultureIgnoreCase))
            {
                vault.AddToAccount(HttpContext.User.Identity.Name, insecure: amount);
            }

            if ("withdraw".Equals(mode, StringComparison.InvariantCultureIgnoreCase))
            {
                vault.AddToAccount(HttpContext.User.Identity.Name, insecure: -amount);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Nonstandard(double amount, string mode)
        {
            if ("deposit".Equals(mode, StringComparison.InvariantCultureIgnoreCase))
            {
                vault.AddToAccount(HttpContext.User.Identity.Name, nonstandard: amount);
            }

            if ("withdraw".Equals(mode, StringComparison.InvariantCultureIgnoreCase))
            {
                vault.AddToAccount(HttpContext.User.Identity.Name, nonstandard: -amount);
            }

            return RedirectToAction("Index", "Home");
        }
	}
}