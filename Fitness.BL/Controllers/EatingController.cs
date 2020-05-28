using System.Collections.Generic;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class EatingController:BaseController
    {
        public readonly User User;
        public readonly Eating Eating;
        public List<Food> Foods { get; set; }

        public EatingController(User user)
        {
            User = user ?? throw new System.ArgumentNullException(nameof(user));
            LoadFoods();
            Eating = new Eating(User);
        }

        private void SaveFoods()
        {
            base.Save<Food>("foods.dat", Foods);
        }

        private void LoadFoods()
        {
            Foods = base.Load<Food>("foods.dat")?? new List<Food>();
        }
    }
}
