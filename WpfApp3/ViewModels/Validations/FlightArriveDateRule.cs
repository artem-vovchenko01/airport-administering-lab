using System;
using System.Globalization;
using System.Windows.Controls;

namespace WpfApp3.ViewModels.Validations
{
    public class FlightArriveDateRule : ValidationRule
    {
        
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null) return new ValidationResult(false, "Provide a value, null isn't allowed");
            try
            {
                var time = DateTime.Parse((string) value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, "Not a date");
            }
            

            return ValidationResult.ValidResult;
        }
    }
}