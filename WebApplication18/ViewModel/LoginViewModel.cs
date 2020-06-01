using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication18.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [StringLength(30, ErrorMessage = "{0} alanı en az 2 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        //asdasdasdasdas


        [Required(ErrorMessage = "{0} alanı boş geçilemez!")]
        [StringLength(30, ErrorMessage = "{0} alanı en az 2 karakter uzunluğunda olmalıdır!", MinimumLength = 2)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
    }
}