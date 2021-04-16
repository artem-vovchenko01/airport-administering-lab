using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp3.ViewModels.Validations
{
    public class FlightDepartDateRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var time = (DateTime) value;
           
            return ValidationResult.ValidResult;
        }
    }
}