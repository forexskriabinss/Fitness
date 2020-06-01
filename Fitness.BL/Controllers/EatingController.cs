using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class EatingController : BaseController
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";

        public readonly User User;
        public readonly Eating Eating;
        public readonly List<Food> Foods;

        public EatingController(User user)
        {
            User = user ?? throw new System.ArgumentNullException(nameof(user));
            Foods = GetAllFoods();
            Eating = GetFirstEating();
        }

        /// <summary>
        /// Add new food to ration with amount of food
        /// </summary>
        /// <param name="food">Food which eating user</param>
        /// <param name="weight">Amount of food</param>
        public void Add(Food food, double weight)
        {
            var findedFood = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (findedFood == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
            }
            else
            {
                Eating.Add(findedFood,weight);
            }
            Save();
        }

        /// <summary>
        ///Saving to .dat file
        ///TODO: DB saver
        /// </summary>
        private void Save()
        {
            base.Save<Food>(FOODS_FILE_NAME, Foods);
            base.Save<Eating>(EATINGS_FILE_NAME, new List<Eating> { Eating });
        }
        /// <summary>
        /// Get first? Eating from file
        /// </summary>
        /// <returns></returns>
        private Eating GetFirstEating()
        {
            return base.Load<Eating>(EATINGS_FILE_NAME).FirstOrDefault() ?? new Eating(User);
        }

        private List<Food> GetAllFoods()
        {
            return base.Load<Food>(FOODS_FILE_NAME) ?? new List<Food>();
        }
    }
}
