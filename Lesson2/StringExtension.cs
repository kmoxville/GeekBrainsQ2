using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2
{
    internal static class StringExtension
    {
        public static string Reverse(this string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;

            char[] chars = new char[value.Length];

            for (int i = 0; i < value.Length; i++)
            {
                chars[^(i + 1)] = value[i];
            }

            return new string(chars);
        }
    }
}
