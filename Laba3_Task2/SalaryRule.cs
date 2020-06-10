using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laba3_Task2
{
    class SalaryRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            double convertedValue;
           
            try
            {
                convertedValue = Double.Parse((string)value, new NumberFormatInfo());
            }
            catch
            {
                return new ValidationResult(false, "Недопустимые символы. Зарплата должно быть числом");
            }

            if (convertedValue < 0)
            {
                return new ValidationResult(false, "Зарплата не может быть меньше 0.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
