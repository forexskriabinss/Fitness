using System;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }
        public double CaloriesPerMinute { get; }

        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

    }
}
