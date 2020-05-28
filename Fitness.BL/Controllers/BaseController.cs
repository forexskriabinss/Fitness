using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using NUnit.Framework;

namespace Fitness.BL.Controllers
{
    public abstract class BaseController
    {
        protected void Save<T>(string fileName, List<T> list)
        {
            if (list is null)
            {
                throw new System.ArgumentNullException($"List is null", nameof(T));
            }

            var formatter = new BinaryFormatter();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, list);
            }
        }

        protected virtual List<T> Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            var result = new List<T>();
            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0)
                    result = formatter.Deserialize(fs) as List<T>;
            }
            return result;
        }
    }
}
