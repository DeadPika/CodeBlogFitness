using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    public class EatingController : ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
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
            Save(FOODS_FILE_NAME, Foods);
            Save(EATINGS_FILE_NAME, Eating);
        }
        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(User);
        }
        private List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();
        }
    }
}
