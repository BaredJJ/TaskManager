using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace TaskManager.Models
{
    public class NextDateAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (!(value is DateTime date)) return false;

            return (date > DateTime.Now);
        }

        public override string FormatErrorMessage(string name) =>
            string.Format(CultureInfo.CurrentCulture, ErrorMessageString, name);
    }
}
