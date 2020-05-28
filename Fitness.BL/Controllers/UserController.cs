using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class UserController
    {
        public List<User> Users { get; private set; }
        public User CurrentUser { get; private set; }
        public bool IsNewUser { get; } = false;


        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentException("Name is incorrect", nameof(userName));
            }

            LoadUsers();
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
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new System.ArgumentException("Gender is not valid", nameof(gender));
            }
        
            if (birth < DateTime.Now.AddYears(-100) )
            {
                throw new ArgumentException("Age more than 100 years", nameof(birth));
            }
            if (weight<10||weight>500)
            {
                throw new ArgumentException("Unreal Weight", nameof(weight));
            }
            if (height<50 || height>300)
            {
                throw new ArgumentException("Unreal Height", nameof(weight));
            }
            Gender gen = new Gender(gender);
            CurrentUser.Gender = gen;
            CurrentUser.DateOfBirth = birth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }

        private void Save()
        {
            if (Users is null)
            {
                throw new System.ArgumentNullException("User is null" ,nameof(User));
            }
            
            var formatter = new BinaryFormatter();
            using(var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }

        private void LoadUsers()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length == 0)
                    Users = new List<User>();
                else
                    Users = formatter.Deserialize(fs) as List<User>;
                if (Users == null)
                    Users = new List<User>();
            }
        }
    }
}
