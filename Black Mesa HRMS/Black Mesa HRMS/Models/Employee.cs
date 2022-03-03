using Black_Mesa_HRMS.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Black_Mesa_HRMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [StringLength(50)]
        public JobPosition JobPosition { get; set; }
        public int JobPositionId { get; set; }
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        public bool Gender { get; set; }
        [StringLength(9)]
        public string CardNo { get; set; }
        [StringLength(7)]
        public string PersonalNo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Countries Nationality { get; set; }
        [StringLength(7)]
        public string FinCode { get; set; }
        [StringLength(maximumLength: 15)]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 15)]
        public string HomeNumber { get; set; }
        [StringLength(maximumLength: 100)]
        public string Email { get; set; }
        [StringLength(maximumLength: 200)]
        public string Address { get; set; }
        [StringLength(6)]
        public string ZipCode { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FormImage { get; set; }
    }
}
