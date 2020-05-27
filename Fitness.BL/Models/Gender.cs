using System;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Gender
    {
        public readonly string Name;

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new System.ArgumentException("Incorrect gender name!", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}