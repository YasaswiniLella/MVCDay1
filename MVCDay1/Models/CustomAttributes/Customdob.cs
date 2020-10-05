using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVCDay1.Models.CustomAttributes
{
    public class Customdob:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dt = Convert.ToDateTime(value);
            if (value == null)
            {
                return new ValidationResult("Date time is required");
            }
            if (dt.Year<2002)
            {
                return new ValidationResult("Age should be greater than 18");
            }
            else
            {
                return ValidationResult.Success;
            }
        }

    }
}