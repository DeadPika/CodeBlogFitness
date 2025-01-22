using System;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Упражнение.
    /// </summary>
    public class Exercise
    {
        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Конец упражнения.
        /// </summary>
        public DateTime Finish { get; set; }
        /// <summary>
        /// Активность.
        /// </summary>
        public Activity Activity { get; set; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public User User { get; }
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            // TODO: Проверка.

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
