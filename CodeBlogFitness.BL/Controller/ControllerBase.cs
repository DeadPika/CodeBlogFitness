using CodeBlogFitness.BL.Model;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        protected IDataSaver saver = new SerializeDataSaver();

        protected void Save(string fileName, object item)
        {
           saver.Save(fileName, item);
        }

        protected T Load<T>(string fileName) where T : class
        {
            return saver.Load<T>(fileName);
        }
    }
}
