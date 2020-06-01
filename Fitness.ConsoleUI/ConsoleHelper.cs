using System;

using C = System.Console;


namespace Fitness.ConsoleUI
{
    internal static class ConsoleHelper
    {
      
        public static string ReadLine(string text, ConsoleColor color = ConsoleColor.White, bool clear=true)
        {
            if (clear)
                C.Clear();
            C.ForegroundColor = color;
            C.Write(text);
            var result = C.ReadLine();
            return result;
        }
        public static string ParseString(string name, bool clear=true)
        {
            var str = string.Empty;
            do
            {
                str = ReadLine($"{name}: ", clear:clear);
            }
            while (string.IsNullOrWhiteSpace(str));
            return str;
        }

        public static double ParseDouble(string name, bool clear = true)

        {
            var str = string.Empty;
            double result;
            do
            {
                str = ReadLine($"{name}: ", ConsoleColor.Green, clear);
            }
            while (!double.TryParse(str, out result));
            return result;
        }

        public static DateTime ParseBirthday()
        {
            var birth = string.Empty;
            DateTime result;
            do
            {
                birth = ReadLine("Please, enter your date of birth:");
            }
            while (!DateTime.TryParse(birth, out result));
            return result;
        }
    }
}
