using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Приём пищи.
    /// </summary>
    public class Eating
    {
        public int Id { get; set; }
        public DateTime Moment { get; set; }
        public List<FoodPortion> Foods { get; set; }
        //public List<KeyValuePair<Food, double>> Foods { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public Eating() { }
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть пустым!", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new List<FoodPortion>();
        }

        public void Add(Food food, double weight)
        {
            int index = Foods.FindIndex(item => item.Food.Name.Equals(food.Name));

            if (index == -1)
            {
                Foods.Add(new FoodPortion(food, weight));
            }
            else
            {
                var existing = Foods[index];
                Foods[index] = new FoodPortion(existing.Food, existing.Weight + weight);
            }
            //var key = Foods.Select(item => item.Key).FirstOrDefault(f => f.Name.Equals(food.Name));
            //if (key == null) { Foods.Add(food, weight); }
            //else { Foods[key] += weight; }
        }
    }
}
