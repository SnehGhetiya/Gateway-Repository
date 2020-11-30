using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using SourceControlAssignment1.CustomValidation;

namespace SourceControlAssignment1.Models
{
    public class Employee
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter first name")]
        [Display(Name = "First Name")]
        [StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter middle name")]
        [Display(Name = "Middle Name")]
        [StringLength(30, MinimumLength = 3)]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Enter last name")]
        [Display(Name = "Last Name")]
        [StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Choose your gender")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(20,80, ErrorMessage = "Age must be between 20-80 in years.")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Enter your date of birth")]
        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "Enter your joining date")]
        [Display(Name = "Joining Dateh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [JoiningDate(ErrorMessage = "Joining date must be less or equal to the current date")]
        public DateTime JoiningDate { get; set; }

        [Required(ErrorMessage = "Enter mobile number")]
        [Phone]
        [Display(Name = "Mobile number")]
        [RegularExpression(@"((\+)([0-9]{2})([ ])\d{5}([ ])\d{5})$", ErrorMessage = "Number must be like +91 98765 43210")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Enter your mail address")]
        [EmailAddress]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect email format")]
        public string Email { get; set; }

        public string Address { get; set; }

        [Required(ErrorMessage = "Enter your designation")]
        public string Designation { get; set; }

        [Required(ErrorMessage = "Enter your credit card number")]
        [RegularExpression(@"\d{4}[-]\d{4}[-]\d{4}[-]\d{4}$", ErrorMessage = "Format must be like xxxx-xxxx-xxxx-xxxx")]
        [DataType(DataType.CreditCard)]
        public string CreditCard { get; set; }

        [Required(ErrorMessage = "Enter your salary")]
        [Range(25000, 250000, ErrorMessage = "Salary must be in between Rs. 25000 to Rs. 250000")]
        public int Salary { get; set; }
    }
}