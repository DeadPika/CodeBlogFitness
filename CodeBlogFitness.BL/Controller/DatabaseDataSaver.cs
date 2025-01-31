using CodeBlogFitness.BL.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace CodeBlogFitness.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        private IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public T Load<T>(string fileName) where T : class
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsbuilder = new DbContextOptionsBuilder<FitnessContext>();
            optionsbuilder.UseSqlServer(connectionString);
            using (var db = new FitnessContext(optionsbuilder.Options))
            {
                return db.Set<T>().FirstOrDefault();
            }
        }

        public void Save(string fileName, object item)
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsbuilder = new DbContextOptionsBuilder<FitnessContext>();
            optionsbuilder.UseSqlServer(connectionString);
            using (var db = new FitnessContext(optionsbuilder.Options))
            {
                var type = item.GetType();
                if (type == typeof(User))
                {
                    db.Users.Add(item as User);
                }
                else if(type == typeof(Gender))
                {
                    db.Genders.Add(item as Gender);
                }
                else if (type == typeof(Activity))
                {
                    db.Activities.Add(item as Activity);
                }
                else if (type == typeof(Eating))
                {
                    db.Eatings.Add(item as Eating);
                }
                else if (type == typeof(Exercise))
                {
                    db.Exercises.Add(item as Exercise);
                }
                else if (type == typeof(Food))
                {
                    db.Foods.Add(item as Food);
                }

                db.SaveChanges();
            }
        }
    }
}
