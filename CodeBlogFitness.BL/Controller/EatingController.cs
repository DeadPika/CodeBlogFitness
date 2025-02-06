using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private readonly User User;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(User));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var currentFood = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (currentFood == null)
            {
                Foods.Add(food);
                this.Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(currentFood, weight);
                Save();
            }
        }
        private void Save()
        {
            Save(Foods);
            Save(new List<Eating> { Eating });
        }
        private Eating GetEating()
        {
            return Load<Eating>().FirstOrDefault() ?? new Eating();
        }
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }
    }
}
