using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VaktiImProject.Models
{
    public class Login
    {
        [Required(ErrorMessage=" Ju lutem plotësoni username.", AllowEmptyStrings=false)]
        public string Usename { get; set; }
        [Required(ErrorMessage = " Ju lutem plotësoni passwordin.", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}