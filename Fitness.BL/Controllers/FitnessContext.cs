using Fitness.BL.Models;
using System.Data.Entity;

namespace Fitness.BL.Controllers
{
    public class FitnessContext:DbContext
    {
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Eating> Eatings { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Gender> Genders { get; set; }


        public FitnessContext() : base("name=ConnectionDB") { }
    }
}
