using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication18.ViewModel
{
    public class UserViewModel
    {
        //User viewdeki idleri sil
        //public int Userid { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [StringLength(30, ErrorMessage = "{0} alanı en az 2 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [EmailAddress(ErrorMessage = "{0} alanı en az 2 karakter uzunluğunda olmalıdır!")]
        [Display(Name = "Email")]
        [StringLength(30, ErrorMessage = "{0} alanı en az 2 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        public string UserEmail { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [StringLength(30, ErrorMessage = "{0} alanı en az 2 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }

    }
}