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


            C.WriteLine(userController.CurrentUser);
            C.ReadKey();
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
