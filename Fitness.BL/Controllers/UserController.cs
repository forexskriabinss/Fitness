using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class UserController: BaseController
    {
        private const string USERS_FILE_NAME = "users.dat";
        public List<User> Users { get; private set; }
        public User CurrentUser { get; private set; }
        public bool IsNewUser { get; } = false;


        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Name is incorrect", nameof(userName));
            }

            Users = GetUsers();
            var user = Users.FirstOrDefault(x => x.Name == userName);
            if (user == null)
            {
                IsNewUser = true;
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
            }
            else
            {
                CurrentUser = user;
             
            }
        }

        public void AddUserData(string gender, DateTime birth, double weight, double height)
        {
            //TODO: Correct validation
            //if (string.IsNullOrWhiteSpace(gender))
            //{
            //    throw new System.ArgumentException("Gender is not valid", nameof(gender));
            //}
            //if (birth < DateTime.Now.AddYears(-100) )
            //{
            //    throw new ArgumentException("Age more than 100 years", nameof(birth));
            //}
            //if (weight<10||weight>500)
            //{
            //    throw new ArgumentException("Unreal Weight", nameof(weight));
            //}
            //if (height<50 || height>300)
            //{
            //    throw new ArgumentException("Unreal Height", nameof(weight));
            //}
            Gender gen = new Gender(gender);
            CurrentUser.Gender = gen;
            CurrentUser.DateOfBirth = birth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            SaveUsers();
        }

        private void SaveUsers()
        {
            base.Save<User>(USERS_FILE_NAME, Users);
        }

        private List<User> GetUsers()
        {
            return base.Load<User>(USERS_FILE_NAME);
        }

    }
}
