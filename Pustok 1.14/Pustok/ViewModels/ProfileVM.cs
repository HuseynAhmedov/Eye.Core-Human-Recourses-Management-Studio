using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.ViewModels
{
    public class ProfileVM
    {
        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string FullName { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 5)]
        public string UserName { get; set; }

        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        #nullable enable
        [StringLength(maximumLength: 100, MinimumLength = 8), DataType(DataType.Password)]
        public string?  CurrentPassword { get; set; }

        [StringLength(maximumLength: 100, MinimumLength = 8), DataType(DataType.Password)]
        public string? NewPassword { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 8), DataType(DataType.Password), Compare(nameof(NewPassword))]
        public string? NewPasswordRepeat { get; set; }
    }
}
