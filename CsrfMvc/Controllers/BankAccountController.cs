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
        public ActionResult Secure(double amount, string action)
        {
            if("deposit".Equals(action, StringComparison.InvariantCultureIgnoreCase)){
                vault.AddToAccount(HttpContext.User.Identity.Name, amount);
            }

            if("withdraw".Equals(action, StringComparison.InvariantCultureIgnoreCase)){
                vault.AddToAccount(HttpContext.User.Identity.Name, -amount);
            }

            return RedirectToAction("Index", "Home");
        }
	}
}