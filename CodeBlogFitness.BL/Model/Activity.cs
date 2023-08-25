using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; }
        public double CaloriesPerSecond { get; }
        public double CaloriesPerMinute { get; }
        public Activity(string name, double caloriesPerSecond)
        {

            // Проверка.
            Name = name;
            CaloriesPerSecond = caloriesPerSecond;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
