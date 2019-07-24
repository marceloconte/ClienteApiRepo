using System;
using System.Text.RegularExpressions;

namespace Clientes.Framework
{
    public static class StringExtensions
    {
        public static bool IsNull(this string value)
        {
            return value == null;
        }

        public static bool IsNotNull(this string value) => !value.IsNull();

        public static bool IsEmpty(this string value)
        {
            return value.IsNull() || (value.Trim() == "");
        }

        public static bool IsNotEmpty(this string value)
        {
            return !value.IsEmpty();
        }


        public static string ToMaskedCPF(this string value)
        {
            if (value.IsEmpty() || value.Length != 11) return value;

            var masked = value.Insert(3, ".").Insert(7, ".").Insert(11, "-");

            return masked;
        }

        public static bool Is<T>(this string value) where T : struct => value.TryCastTo<T>() != null;
        public static bool IsNot<T>(this string value) where T : struct => !value.Is<T>();

        public static T CastTo<T>(this string value)
        {
            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static T? TryCastTo<T>(this string value) where T : struct
        {
            try
            {
                return value.CastTo<T>();
            }
            catch
            {
                return null;
            }
        }

        public static bool HasLenghtLessThan(this string value, int maxCharacter)
        {
            return value.IsNotEmpty() && value.Length < maxCharacter;
        }

        public static bool HasLenghtMoreThan(this string value, int maxCharacter)
        {
            return !value.HasLenghtLessThan(maxCharacter);
        }

        public static bool IsCPFValid(this string value)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            var cpf = value.Trim().Replace(".", "").Replace("-", "");

            switch (cpf)
            {
                case "11111111111":
                case "00000000000":
                case "2222222222":
                case "33333333333":
                case "44444444444":
                case "55555555555":
                case "66666666666":
                case "77777777777":
                case "88888888888":
                case "99999999999":
                    return false;
            }

            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();

            return cpf.EndsWith(digito);


        }

        public static bool IsNotCPFValid(this string value)
        {
            return !value.IsCPFValid();
        }

    }
}
