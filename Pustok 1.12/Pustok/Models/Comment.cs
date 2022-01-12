using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pustok.Models
{
    public enum commentStatus
    {
        Pending = 1,
        Accepted = 2,
        Denied = 3,
    }

    public class Comment
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public string AppUserId { get; set; }
        public int ProductID { get; set; }
        public string CommentText { get; set; }
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [StringLength(maximumLength: 50)]
        public string FullName { get; set; }
        [Required]
        [Range(1, 5)]
        public int StarCount { get; set; }
        public string UserName { get; set; }
        public DateTime TimeAdded { get; set; }
        public AppUser AppUser { get; set; }

        public commentStatus Status { get; set; }
    }
}
