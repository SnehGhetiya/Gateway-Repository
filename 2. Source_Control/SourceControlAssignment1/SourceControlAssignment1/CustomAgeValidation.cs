using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SourceControlAssignment1
{
    public class CustomAgeValidation : ValidationAttribute
    {
        int _minAge = 18;
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int minimum = (int)value;
                if (minimum >= _minAge)
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult("Age must be greater than 18");
        }
    }
}