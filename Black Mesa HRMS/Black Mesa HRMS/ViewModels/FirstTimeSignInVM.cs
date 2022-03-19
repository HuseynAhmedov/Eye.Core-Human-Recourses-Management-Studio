using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class FirstTimeSignInVM
    {
        public string UserName { get; set; }
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string NewPasswordRepeat { get; set; }
    }
}
