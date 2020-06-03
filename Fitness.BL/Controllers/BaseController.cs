using System.Collections.Generic;

namespace Fitness.BL.Controllers
{
    public abstract class BaseController
    {
        private readonly IDataStorage dataStorage = new DatabaseStorage();
        
        protected void Save<T>(List<T> list) where T:class
        {
            dataStorage.Save(list);
        }

        protected virtual List<T> Load<T>() where T:class
        {
            return dataStorage.Load<T>();
        }
    }
}
