using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CodeBlogFitness.BL.Controller
{
    public class DatabaseDataSaver : IDataSaver
    {
        private IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public List<T> Load<T>() where T : class
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsbuilder = new DbContextOptionsBuilder<FitnessContext>();
            optionsbuilder.UseSqlServer(connectionString);

            using (var db = new FitnessContext(optionsbuilder.Options))
            {
                var result = db.Set<T>().Where(l => true).ToList();
                return result;
            }
        }

        public void Save<T>(List<T> item) where T : class
        {
            string? connectionString = configuration.GetConnectionString("DefaultConnection");
            var optionsbuilder = new DbContextOptionsBuilder<FitnessContext>();
            optionsbuilder.UseSqlServer(connectionString);
            using (var db = new FitnessContext(optionsbuilder.Options))
            {
                db.Set<T>().AddRange(item);

                db.SaveChanges();
            }
        }
    }
}