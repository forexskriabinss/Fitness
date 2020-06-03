using System;
using System.Collections.Generic;
using System.Linq;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Eating
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public  User User { get; set; }
        public  DateTime Moment { get; set; } = DateTime.Now;

        public Dictionary<Food, double> Foods { get; set; }

        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("User cannot be empty!", nameof(user));
            Foods = new Dictionary<Food, double>();
        }

        public void Add(Food food, double weight)
        {
            var existedFood = Foods.FirstOrDefault(f=> f.Key==food).Key;
            if(existedFood == null)
            {
                Foods.Add(food, weight);
            }
            else
            {   
                Foods[existedFood] += weight;
            }
        }

    }
}
