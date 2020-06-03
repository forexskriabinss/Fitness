using System.Collections.Generic;
using System.Linq;
using Fitness.BL.Models;

namespace Fitness.BL.Controllers
{
    public class DatabaseStorage : IDataStorage
    {
        public List<T> Load<T>() where T : class
        {
            using (var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(t => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> list) where T : class
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().AddRange(list);
                db.SaveChanges();
            }
        }
    }
}
