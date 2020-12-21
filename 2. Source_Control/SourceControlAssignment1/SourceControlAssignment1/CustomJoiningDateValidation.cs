using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlAssignment1
{
    public class CustomJoiningDateValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dateTime = Convert.ToDateTime(value);
            if(dateTime <= DateTime.Now)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Joining Date must be less or equal to the current date");
        }
    }
}