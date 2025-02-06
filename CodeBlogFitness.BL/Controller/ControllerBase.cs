using CodeBlogFitness.BL.Model;
using System.Collections.Generic;
using System.IO;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase
    {
        private readonly IDataSaver manager = new DatabaseDataSaver();

        protected void Save<T>(List<T> item) where T : class
        {
            manager.Save(item);
        }

        protected List<T> Load<T>() where T : class
        {
            return manager.Load<T>();
        }
    }
}
