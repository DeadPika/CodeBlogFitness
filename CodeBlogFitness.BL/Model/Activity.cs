using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Активность.
    /// </summary>
    public class Activity
    {
        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Сжигаемые калории за каждую минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }
        public Activity(string name, double caloriesPerMinute)
        {
            // TODO: Проверка.

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
