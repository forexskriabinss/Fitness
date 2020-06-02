using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controllers
{
    public class SerializableStorage : IDataStorage
    {

        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();
            var result = new List<T>();
            var fileName = typeof(T).Name;
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    result = formatter.Deserialize(fs) as List<T>;
            }
            return result;
        }

        public void Save<T>(List<T> list) where T : class
        {
            if (list is null)
            {
                throw new System.ArgumentNullException($"List is null", nameof(T));
            }
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name;
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }
    }
}
