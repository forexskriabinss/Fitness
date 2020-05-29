using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class EatingController:BaseController
    {
        private const string FOODS_FILE_NAME = "foods.dat";

        private const string EATING_FILE_NAME = "eatings.dat";

        public readonly User User;
        public readonly List<Food> Foods;
        public readonly Eating Eating;


        public EatingController(User user)
        {
            User = user ?? throw new System.ArgumentNullException(nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }

        public void Add(Food food, double weight)
        {
            var findedFood = Foods.SingleOrDefault(f => f == food);
            if(food==null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(findedFood, weight);
                Save();
            }

        }

        private void Save()
        {
            base.Save<Food>(FOODS_FILE_NAME, Foods);
            base.Save<Eating>(FOODS_FILE_NAME, new List<Eating>() { Eating});
        }

        private List<Food> GetAllFoods()
        {
            return base.Load<Food>(FOODS_FILE_NAME) ?? new List<Food>();
        }
        private Eating GetEating()
        {
            return base.Load<Eating>(EATING_FILE_NAME).FirstOrDefault() ?? new Eating(User);
        }
    }
}
