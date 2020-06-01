using System;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Exercise
    {
        public Activity Activity { get; set; }
        public User User { get; }
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }

    }
}
