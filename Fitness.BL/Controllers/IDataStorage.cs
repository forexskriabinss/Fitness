using System.Collections.Generic;

namespace Fitness.BL.Controllers
{
     public interface IDataStorage
    {
         void Save<T>(List<T> list) where T: class;

         List<T> Load<T>() where T: class;
    }
}
