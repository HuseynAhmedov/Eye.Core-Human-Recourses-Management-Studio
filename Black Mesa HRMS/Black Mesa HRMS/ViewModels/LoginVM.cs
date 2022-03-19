using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Signin Id or work email is required")]
        public string SignInId{ get; set; }
        public string Password { get; set; }
    }
}
