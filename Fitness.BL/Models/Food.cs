using System;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Food
    {
        #region Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public double Calories { get; set; }
        public double Proteins { get; set; }
        public double Fats { get; set; }
        public double Carbohydrate { get; set; }
        private double ProteinsPerOneGram { get; set; }
        private double FatsPerOneGram { get; set; }
        private double CarbohydratePerOneGram { get; set; }
        #endregion

        public Food(string name, double calories = 0, double proteins = 0, double fats = 0, double carbohydrate = 0)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Product is null", nameof(name));
            }
            calories = negativeCheckingDouble(calories);
            proteins = negativeCheckingDouble(proteins);
            fats = negativeCheckingDouble(fats);
            carbohydrate = negativeCheckingDouble(carbohydrate);

            Name = name;
            Calories = calories;
            Proteins = proteins;
            Fats = fats;
            Carbohydrate = carbohydrate;

            ProteinsPerOneGram = proteins / 100.0;
            FatsPerOneGram = Fats / 100.0;
            CarbohydratePerOneGram = Carbohydrate / 100.0;
        }


        private double negativeCheckingDouble(double val)
        {
            return val < 0 ? default(double) : val;
        }

        public override string ToString()
        {
            return Name;
        }


    }
}
