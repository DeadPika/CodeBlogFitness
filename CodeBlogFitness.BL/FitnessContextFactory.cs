using CodeBlogFitness.BL.Controller;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CodeBlogFitness.BL
{
    public class FitnessContextFactory : IDesignTimeDbContextFactory<FitnessContext>
    {
        public FitnessContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FitnessContext>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=FitnessDB;Integrated Security=True;TrustServerCertificate=True;");
            return new FitnessContext(optionsBuilder.Options);
        }
    }
}
