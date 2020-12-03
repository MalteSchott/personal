using EmployeeApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace EmployeeApp.Services
{
    public class TextValidation : ValidationRule
    {
        //Validate if employee naming convention is met
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            
            Employee employee = (value as BindingGroup).Items[0] as Employee;

            bool isValid = ValidateEmployee(employee);

            if (!isValid)
            {
                return new ValidationResult(false, "Name can only contain letters.");

            }else
            {
                return ValidationResult.ValidResult;
            }           
        }
        //Conditions
        public bool ValidateEmployee(Employee employee)
        {
            bool isValid = employee.FirstName == null || employee.FirstName.All(Char.IsLetter);
            isValid &= employee.LastName == null || employee.LastName.All(Char.IsLetter);
            return isValid;
        }
    }
}
