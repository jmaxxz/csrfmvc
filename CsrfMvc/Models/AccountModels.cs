using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace CsrfMvc.Models
{

    public class UserProfile
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }


    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        [AllowHtml]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [AllowHtml]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
