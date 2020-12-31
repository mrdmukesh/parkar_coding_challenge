using EmployeeRegistration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRegistration.ViewModels
{
    public class RegisterViewModel
    {
       [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Password )]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",ErrorMessage = "Password and Confirm Password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public Gender Genders { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public long Phone { get; set; }
       
        public string Question { get; set; }
       
        public string Answer { get; set; }
    }
}
