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
                var birth = ReadLineWithClear("Please, enter your date of birth:");
                var weight = ReadLineWithClear("Please, enter your weight:", ConsoleColor.Red);
                var height = ReadLineWithClear("Please, enter your height:", ConsoleColor.Green);
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
    }
}
