using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Гендер.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол.
        /// </summary>
        /// <param name="name">Имя пола.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
