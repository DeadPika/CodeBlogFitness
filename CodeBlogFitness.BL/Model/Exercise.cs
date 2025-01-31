using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Упражнение.
    /// </summary>
    public class Exercise
    {
        public int Id { get; set; }
        /// <summary>
        /// Начало упражнения.
        /// </summary>
        public DateTime Start { get; set; }
        /// <summary>
        /// Конец упражнения.
        /// </summary>
        public DateTime Finish { get; set; }
        public int ActivityId { get; set; }
        /// <summary>
        /// Активность.
        /// </summary>
        public virtual Activity Activity { get; set; }
        public int UserId { get; set; }
        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        public Exercise() { }
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
