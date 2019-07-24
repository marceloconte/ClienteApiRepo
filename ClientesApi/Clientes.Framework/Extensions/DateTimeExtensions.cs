
using System;
using System.Net;
using System.Text.RegularExpressions;

namespace Clientes.Framework
{

    public static class DateTimeExtensions
    {
        public static bool IsNull(this DateTime value)
        {
            return value == null;
        }

        public static bool IsNotNull(this DateTime value) => !value.IsNull();

        public static bool IsEmpty(this DateTime value)
        {
            return value.IsNull() || (value == default(DateTime));
        }

        public static bool IsNotEmpty(this DateTime value)
        {
            return !value.IsEmpty();
        }

        public static int ToAge(this DateTime value)
        {
            var birthdate = value;
            var today = DateTime.Now;
            var age = today.Year - birthdate.Year;
            if (birthdate > today.AddYears(-age)) age--;

            return age;
        }
    }
}
