
namespace CodeBlogFitness.BL.Model
{
    public class FoodPortion
    {
        public int Id { get; set; }
        public Food Food { get; set; } 
        public double Weight { get; set; }
        public FoodPortion() { }
        public FoodPortion(Food food, double weight)
        {
            Food = food;
            Weight = weight;
        }
    }

}
