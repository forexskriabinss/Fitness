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
            var name = ConsoleHelper.ParseString("Please Enter name");
            UserController userController = new UserController(name);

            if (userController.IsNewUser)
            {
                EnterNewUser(userController);
            }
            C.Clear();
            C.WriteLine(userController.CurrentUser);
            while(true)
            {
                var choice = UserChoice();
                C.Clear();
                if (choice == ConsoleKey.E)
                {
                    EatingController eatingController = new EatingController(userController.CurrentUser);
                    var eating = EnterEating();
                    eatingController.Add(eating.food, eating.weight);
                   
                }
                if (choice == ConsoleKey.Escape)
                    break;
            }
        }

        private static (Food food, double weight) EnterEating()
        {
            var foodName = ConsoleHelper.ParseString("Product name", clear:false);
            var proteins = ConsoleHelper.ParseDouble("proteins", clear: false);
            var fats = ConsoleHelper.ParseDouble("fats", clear: false);
            var carbohydrate = ConsoleHelper.ParseDouble("carbohydrate", clear: false);

            Food food = new Food(foodName, proteins, fats, carbohydrate);
            var weight = ConsoleHelper.ParseDouble("weight: ", clear: false);
            return (food, weight);
        }

        private static void EnterNewUser(UserController userController)
        {
            var gender = ConsoleHelper.ParseString("Please, enter your gender:");
            var birth = ConsoleHelper.ParseBirthday();
            var weight = ConsoleHelper.ParseDouble("weight");
            var height = ConsoleHelper.ParseDouble("height");
            userController.AddUserData(gender, birth, weight, height);
        }

        private static ConsoleKey UserChoice()
        {
            ConsoleKey key;
            do
            {
                C.WriteLine("What do you want?");
                C.WriteLine("E - Eating");
                key = C.ReadKey().Key;
            } while (key != ConsoleKey.E);
            return key;
        }
    }
}
