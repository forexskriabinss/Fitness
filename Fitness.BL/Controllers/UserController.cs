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
            }
            else
                CurrentUser = user;
        }

        public void AddUserData(string gender, string birth, string w, string h)
        {
            if (string.IsNullOrWhiteSpace(gender))
            {
                throw new System.ArgumentException("Gender is not valid", nameof(gender));
            }
        
            if (!DateTime.TryParse(birth, out DateTime dateOfBirth))
            {
                throw new ArgumentException("Wrong date of birth", nameof(dateOfBirth));
            }
            if (!Double.TryParse(w, out double weight))
            {
                throw new ArgumentException("Weight must be double", nameof(w));
            }
            if (!Double.TryParse(h, out double height))
            {
                throw new ArgumentException("Height must be double", nameof(w));
            }
            Gender gen = new Gender(gender);
            CurrentUser = new User(CurrentUser.Name, gen, dateOfBirth, weight, height);
            Users.Add(CurrentUser);
        }

        public void Save()
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
