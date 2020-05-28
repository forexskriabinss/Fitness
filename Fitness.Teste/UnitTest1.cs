using System;
using Fitness.BL.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fitness.Teste
{
    [TestClass]
    public class UnitTest1
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
      
    }
}
