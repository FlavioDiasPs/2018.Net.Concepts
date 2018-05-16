using System;
using System.Collections.Generic;
using System.Text;

namespace UsingExtensionMethods.Extensions
{
    public static class StringExtension
    {
        public static int LetterCount(this string value)
        {
            return value.Length;
        }

        public static bool IsBlood(this System.Drawing.Color color)
        {
            return color == System.Drawing.Color.Red;               
        }
    }
}
