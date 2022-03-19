using Black_Mesa_HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.ViewModels
{
    public class ProfileEditVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public bool Gender { get; set; }
        public string Surname { get; set; }
        [StringLength(maximumLength: 15, ErrorMessage = "Phone Number cannot be longer than 15 characters ")]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 15, ErrorMessage = "Home Number cannot be longer than 15 characters ")]
        public string HomeNumber { get; set; }
        [StringLength(maximumLength: 100, ErrorMessage = "Email Address is too long")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        public string Email { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Employee Address is too long")]
        public string Address { get; set; }
        [StringLength(6, ErrorMessage = "ZipCode cannot be longer than 6 characters ")]
        public string ZipCode { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string ImageName { get; set; }
    }
}
