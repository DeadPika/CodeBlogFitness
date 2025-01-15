using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Название еды.
        /// </summary>
        public string Name { get;}
        /// <summary>
        /// Белки.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Жиры.
        /// </summary>
        public double Fats { get; }
        /// <summary>
        /// Углеводы.
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории за 100 грам продукта.
        /// </summary>
        public double Calories { get; }

        private double CaloriesOneGramm { get { return Calories / 100.0;  } }
        private double ProteinsOneGramm { get { return Proteins / 100; } }
        private double FatsOneGramm { get { return Fats / 100; } }
        private double CarbohydratesOneGramm { get { return Carbohydrates / 100; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

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
