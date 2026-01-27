using CafeOtomasyonu.Entities.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace CafeOtomasyonu.Entities.Tools
{
    public class ValidatorTools
    {
        public static bool Validates(IValidator validator, IEntity entity)
        {
            bool result = true;
            ValidationContext<IEntity> context = new ValidationContext<IEntity>(entity);
            var ValidationResult = validator.Validate(context);

            if (!ValidationResult.IsValid)
            {
                string message = "";
                foreach (var error in ValidationResult.Errors)
                {
                    message += error.ErrorMessage + "\n";
                }
                MessageBox.Show(message);
                result = false;
            }
            return result;
        }
    }
}