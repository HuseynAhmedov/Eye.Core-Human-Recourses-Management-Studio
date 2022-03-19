using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Black_Mesa_HRMS.Models
{
    public class AppUser : IdentityUser
    {
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        public DateTime? LastConnectDate { get; set; }
        public DateTime? LastPasswordChangeDate { get; set; }
        public bool Disabled { get; set; }
    }
}
