using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пол.
    /// </summary>
    [Serializable]
    public class Gender
    {
        public int Id { get; set; }
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя полаю </param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name) 
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пумтым или null", nameof(name));
            }
            else
                Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
