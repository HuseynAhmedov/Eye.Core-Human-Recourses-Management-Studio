using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Black_Mesa_HRMS.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public JobPosition JobPosition { get; set; }
        public int JobPositionId { get; set; }
        public AppUser AppUser { get; set; }
        [StringLength(50)]
        [Required(AllowEmptyStrings = false , ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [StringLength(50)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }
        [StringLength(9 , ErrorMessage = "Card No cannot be longer than 9 characters ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Card No is required")]
        public string CardNo { get; set; }
        [StringLength(7 , ErrorMessage = "Personal No cannot be longer than 7 characters ")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Personal No is required")]
        public string PersonalNo { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public Nationality Nationality { get; set; }
        public int NationalityID { get; set; }
        [StringLength(7 , ErrorMessage = "FinCode cannot be longer than 7 characters ")]
        [Required(AllowEmptyStrings = false , ErrorMessage = "FinCode is required")]
        public string FinCode { get; set; }
        [StringLength(maximumLength: 15 , ErrorMessage = "Phone Number cannot be longer than 15 characters ")]
        public string PhoneNumber { get; set; }
        [StringLength(maximumLength: 15 , ErrorMessage = "Home Number cannot be longer than 15 characters ")]
        public string HomeNumber { get; set; }
        [StringLength(maximumLength: 100 , ErrorMessage = "Email Address is too long")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required") ]
        public string Email { get; set; }
        [StringLength(maximumLength: 200, ErrorMessage = "Employee Address is too long")]
        public string Address { get; set; }
        [StringLength(6 , ErrorMessage = "ZipCode cannot be longer than 6 characters ")]
        public string ZipCode { get; set; }
        public bool Fired { get; set; }
        public string signInId { get; set; }
        public DateTime EmployedDate { get; set; }
        public DateTime? FiredDate { get; set; }
        public string Image { get; set; }
        [NotMapped]
        public IFormFile FormImage { get; set; }
    }
}
