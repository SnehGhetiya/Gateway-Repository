//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SourceControlFinalAssignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class tbl_User
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter username")]
        [Display(Name = "Username")]
        [StringLength(10, MinimumLength = 6)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        [StringLength(10, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Firstname")]
        [Display(Name = "Firstname")]
        [StringLength(10, MinimumLength = 6)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Enter Lastname")]
        [Display(Name = "Lastname")]
        [StringLength(10, MinimumLength = 6)]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Incorrect email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter phone number")]
        [Display(Name = "Phone number")]
        [MaxLength(10)]
        [RegularExpression(@"((\+)([0-9]{2})([ ])\d{5}([ ])\d{5})$", ErrorMessage = "Number must be like +91 98765 43210")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Upload profile picture here")]
        [Display(Name = "Profile Picture")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Enter your age")]
        [Display(Name = "Age")]
        [SourceControlFinalAssignment.CustomAttribute.MinAge(18)]
        public int Age { get; set; }
    }

    public partial class tbl_Login
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Usename")]
        public string Username { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
}
