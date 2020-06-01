using System;
using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class ExerciseController:BaseController
    {
        private const string ACTIVITIES_FILE_NAME = "activities.dat";
        private const string EXERCISES_FILE_NAME = "exrcises.dat";

        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }
        private readonly User user;

        public ExerciseController(User user)
        {
            this.user = user;
            Activities = GetAllActivities();
            Exercises = GetAllExercises();

        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if( act==null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }
            Save();
        }

        private void Save()
        {
            base.Save(ACTIVITIES_FILE_NAME, Activities);
            base.Save(EXERCISES_FILE_NAME, Exercises);
        }

        private List<Exercise> GetAllExercises()
        {
            return base.Load<Exercise>(EXERCISES_FILE_NAME);
        }

        private List<Activity> GetAllActivities()
        {
            return base.Load<Activity>(ACTIVITIES_FILE_NAME);
        }
    }
}
