using System;
using System.Linq;
using Fitness.BL.Controllers;
using Fitness.BL.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fitness.Teste
{
    [TestClass]
    public class TestControllers
    {
        [TestMethod]
        public void TestUserController()
        {
            //Arrange
            UserController controller = new UserController("Ivan");
            //Act
            controller.AddUserData("Male", DateTime.Now, 85, 174);
            var users = controller.Users;
            //Assert
            Assert.AreEqual(1, users.Count);
        }

        [TestMethod]
        public void TestEatingController()
        {
            //Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var eatingConroller = new EatingController(userController.CurrentUser);
            var food = new Food(foodName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act
            eatingConroller.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, eatingConroller.Eating.Foods.Last().Key.Name);
        }

        [TestMethod]
        public void TestExerciseController()
        {
            //Arrange
            var user =new User( Guid.NewGuid().ToString());
            var rnd = new Random();
            var controller  = new ExerciseController(user);
            var activity = new Activity(Guid.NewGuid().ToString(), rnd.Next(10,100) );
            // Act
            controller.Add(activity, DateTime.Now, DateTime.Now.AddMinutes(5));
            // Assert
            Assert.AreEqual(activity.Name, controller.Activities.Last().Name);
            Assert.AreEqual(activity.CaloriesPerMinute, controller.Activities.Last().CaloriesPerMinute);

        }



    }
}
