using System;
using System.Text.Json.Serialization;

namespace CodeBlogFitness.BL.Model
{
    public class Food
    {
        public int Id { get; set; }
        /// <summary>
        /// Название еды.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; set; }

        /// <summary>
        /// Калории за 100 грам продукта.
        /// </summary>
        public double Calories { get; set; }
        public virtual ICollection<Eating> Eatings { get; set; }
        public Food() { }
        public Food(string name) : this(name, 0, 0, 0, 0) { }
        [JsonConstructor]
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: Проверка.

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
