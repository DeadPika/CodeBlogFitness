using System.Collections.Generic;

namespace CodeBlogFitness.BL.Controller
{
    public interface IDataSaver<T> where T : class
    {
        void Save(T item);
        List<T> Load();
    }
}
