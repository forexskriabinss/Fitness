using System;
using Fitness.BL.Controllers;
using Fitness.BL.Models;
using C = System.Console;

namespace Fitness.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = ParseString("name");
            UserController userController = new UserController(name);
            if (userController.IsNewUser)
            {
                var gender = ParseString("gender");
                var birth = ParseBirthday();
                var weight = ParseDouble("weight");
                var height = ParseDouble("height");
                userController.AddUserData(gender, birth, weight, height);
            }
            C.WriteLine(userController.CurrentUser);
            var key = WhatAreYouWant();
            if(key == ConsoleKey.E)
            {
                EatingController eatingController = new EatingController(userController.CurrentUser);
                var result = EnterEating();
               
                eatingController.Add(result.food, result.weight);
            }
          

            C.ReadKey();
        }

        private static (Food food, double weight) EnterEating()
        {
            C.Write("Enter food:\t");
            var name = ParseString("food");

            var calories = ParseDouble("calories");
            var proteins = ParseDouble("proteins");
            var fats = ParseDouble("fats");
            var carbohydrate = ParseDouble("fats");

            Food food = new Food(name, calories, proteins, fats, carbohydrate);
            var weight = ParseDouble("weight");
            return (food, weight);
        }

        private static ConsoleKey WhatAreYouWant()
        {
            ConsoleKey key;
            do
            {
                C.WriteLine("What are want?");
                C.WriteLine("E- Eating");
                key = C.ReadKey().Key;
            } while (key != ConsoleKey.E);
            return key;
        }

        static string ReadLineWithClear(string text, ConsoleColor color = ConsoleColor.White)
        {
            C.Clear();
            C.ForegroundColor = color;
            C.Write(text);
            var result = C.ReadLine();
            return result;
        }

        #region User Entering
        static string ParseString(string name)
        {
            var result = string.Empty;
            do
            {
                result = ReadLineWithClear($"Enter {name}: ", ConsoleColor.Blue);
            }
            while (string.IsNullOrWhiteSpace(result));
            return result;
        }

        private static double ParseDouble(string name)

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

        private static DateTime ParseBirthday()
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
        #endregion
    }
}
