using System;
using Fitness.BL.Controllers;
using C = System.Console;

namespace Fitness.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = ReadLineWithClear("Please, enter your name:");
            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                var gender = ReadLineWithClear("Please, enter your gender:", ConsoleColor.Blue);
                var birth = ParseBirthday();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");

                userController.AddUserData(gender, birth, weight, height);
                userController.Save();
            }

            C.WriteLine(userController.CurrentUser);
            C.ReadKey();
        }


        static string ReadLineWithClear(string text, ConsoleColor color = ConsoleColor.White)
        {
            C.Clear();
            C.ForegroundColor = color;
            C.Write(text);
            var result = C.ReadLine();
            return result;
        }

        static double ParseDouble(string name)

        {
            var str = string.Empty;
            double result;
            do
            {
                 str = ReadLineWithClear($"Please, enter your {name}:", ConsoleColor.Green);
            }
            while (!double.TryParse(str, out result));
            return result;
        }
        static DateTime ParseBirthday()
        {
            var birth = string.Empty;
            DateTime result;
            do
            {
                birth = ReadLineWithClear("Please, enter your date of birth:");
            }
            while (!DateTime.TryParse(birth, out result));
            return result;
        }
    }
}
