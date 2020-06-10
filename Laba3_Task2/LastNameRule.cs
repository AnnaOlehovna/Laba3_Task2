using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Laba3_Task2
{
    class LastNameRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value !=null && ((string)value).Any(char.IsDigit))
            {
                return new ValidationResult(false, "В Фамилии не должно быть цифр");
            }
            else
            {
                return ValidationResult.ValidResult;

            }

        }
    }
}
