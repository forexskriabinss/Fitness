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
        public static string ParseString(string text, bool clear=true)
        {
            var str = string.Empty;
            do
            {
                str = ReadLine($"{text}: ", clear:clear);
            }
            while (string.IsNullOrWhiteSpace(str));
            return str;
        }

        public static double ParseDouble(string text, bool clear = true)

        {
            var str = string.Empty;
            double result;
            do
            {
                str = ReadLine($"{text}: ", ConsoleColor.Green, clear);
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
                birth = ReadLine("Please, enter your date of birth (mm.dd.yyyy):");
            }
            while (!DateTime.TryParse(birth, out result));
            return result;
        }

        public static DateTime ParseDateTime(string text)
        {
            var time = string.Empty;
            DateTime result;
            do
            {
                time = ReadLine($"{text}(hh:mm:ss) ");
            }
            while (!DateTime.TryParse(time, out result));
            return result;
        }
    }
}
