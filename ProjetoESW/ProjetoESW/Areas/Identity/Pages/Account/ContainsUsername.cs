using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoESW.Areas.Identity.Pages.Account
{
    public class ContainsUsername : ValidationAttribute
    {
        private string Username { get; set; }
        protected  ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(Username);
            // Get the value of the dependent property 
            var UsernameValue = otherProperty.GetValue(validationContext.ObjectInstance, null);

            Console.WriteLine(UsernameValue.ToString());
            if (!(value.ToString().Contains(UsernameValue.ToString())))
            {
                return ValidationResult.Success;
            }


            return new ValidationResult("Password não pode conter username");
        }

        public ContainsUsername(string username)
        {
            Username = username;
        }
    }
}
