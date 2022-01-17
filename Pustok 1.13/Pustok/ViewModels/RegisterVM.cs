using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string UserName { get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 8), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(maximumLength: 100, MinimumLength = 8), DataType(DataType.Password), Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
        [Required]
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
    }
}
