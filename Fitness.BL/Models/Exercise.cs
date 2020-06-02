using System;

namespace Fitness.BL.Models
{
    [Serializable]
    public class Exercise
    {
        public int Id { get; set; }
        public Activity Activity { get; set; }
        public int ActivityId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

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
