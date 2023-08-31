using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    public class DatabaseDataSaver<T> : IDataSaver<T> where T : class
    {
        public List<T> Load()
        {
            using(var db = new FitnessContext())
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }
        public void  Save(T item)
        {
            using (var db = new FitnessContext())
            {
                db.Set<T>().Add(item);
                db.SaveChanges();
            }
        }
    }
}
