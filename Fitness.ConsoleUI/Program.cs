using System;
using System.Globalization;
using System.Resources;
using Fitness.BL.Controllers;
using Fitness.BL.Models;
using C = System.Console;

namespace Fitness.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //Test resource
            var culture = CultureInfo.CreateSpecificCulture("ru-ru");
            ResourceManager resourceManager = new ResourceManager("Fitness.ConsoleUI.Languages.Messages", typeof(Program).Assembly);
            C.WriteLine(resourceManager.GetString("Hello", culture));
            C.ReadKey();

            var name = ConsoleHelper.ParseString("Please Enter name");
            UserController userController = new UserController(name);

            if (userController.IsNewUser)
            {
                EnterNewUser(userController);
            }

            C.Clear();
            C.WriteLine(userController.CurrentUser);

            while (true)
            {
                var choice = UserChoice();
                C.Clear();
                switch (choice)
                {
                    case ConsoleKey.E:
                        EatingController eatingController = new EatingController(userController.CurrentUser);
                        var eating = EnterEating();
                        eatingController.Add(eating.food, eating.weight);
                        break;
                    case ConsoleKey.A:
                        ExerciseController exerciseController = new ExerciseController(userController.CurrentUser);
                        var exe = EnterExercise();
                        exerciseController.Add(exe.activity, exe.start, exe.end);
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

            }
        }

        private static (Activity activity, DateTime start, DateTime end) EnterExercise()
        {
            var name = ConsoleHelper.ParseString("Exercise:", clear: false);
            var calories = ConsoleHelper.ParseDouble("Calories per Minute", clear: false);
            var start = ConsoleHelper.ParseDateTime("Start time");
            var end = ConsoleHelper.ParseDateTime("End time");
            var activity = new Activity(name, calories);
            return (activity, start, end);
        }

        private static (Food food, double weight) EnterEating()
        {
            var foodName = ConsoleHelper.ParseString("Product name", clear: false);
            var proteins = ConsoleHelper.ParseDouble("proteins", clear: false);
            var fats = ConsoleHelper.ParseDouble("fats", clear: false);
            var carbohydrate = ConsoleHelper.ParseDouble("carbohydrate", clear: false);

            Food food = new Food(foodName, proteins, fats, carbohydrate);
            var weight = ConsoleHelper.ParseDouble("weight", clear: false);
            return (food, weight);
        }

        private static void EnterNewUser(UserController userController)
        {
            var gender = ConsoleHelper.ParseString("Please, enter your gender");
            var birth = ConsoleHelper.ParseBirthday();
            var weight = ConsoleHelper.ParseDouble("weight");
            var height = ConsoleHelper.ParseDouble("height");
            userController.AddUserData(gender, birth, weight, height);
        }

        private static ConsoleKey UserChoice()
        {
            ConsoleKey key;

            C.WriteLine("What do you want?");
            C.WriteLine("E - Eating");
            C.WriteLine("A - Activity");
            C.WriteLine("Q - Exit");

            key = C.ReadKey().Key;
            return key;
        }
    }
}
