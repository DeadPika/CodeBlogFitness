using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace CodeBlogFitness.BL.Controller
{
    public abstract class ControllerBase<T> where T : class
    {
        protected IDataSaver<T> manager = new SerializeDataSaver<T>();
        protected void Save(T item)
        {
            manager.Save(item);
        }
        protected List<T> Load()
        {
            return manager.Load();
        }
    }
}
