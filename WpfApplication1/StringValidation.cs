using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace WpfApplication1
{
    class StringValidation : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            try
            {
                var str = value as string;
                if (str.Length > 0)
                {
                    return new ValidationResult(true, null);
                }
                return new ValidationResult(false, "Morate uneti vrednost za polje.");
            }
            catch
            {
                return new ValidationResult(false, "Nepoznata greska.");
            }
        }

    }
}
