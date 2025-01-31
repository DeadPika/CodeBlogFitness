﻿using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string EXERCISES_FILE_NAME = "exercises.json";
        private const string ACTIVITIES_FILE_NAME = "activities.json";
        private readonly User User;
        public List<Exercise> Exercises { get; }
        public List<Activity> Activities { get; }

        public ExerciseController(User user)
        {
            User = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }
        /// <summary>
        /// Получение всех активностей.
        /// </summary>
        /// <returns></returns>
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITIES_FILE_NAME) ?? new List<Activity>();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);
                act = activity;
            }

            var exercise = new Exercise(begin, end, act, User);
            Exercises.Add(exercise);

            Save();
        }
        /// <summary>
        /// Получить все упражнения.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(EXERCISES_FILE_NAME) ?? new List<Exercise>();
        }
        /// <summary>
        /// Сохранение всех упражнений и активностей.
        /// </summary>
        private void Save()
        {
            Save(EXERCISES_FILE_NAME, Exercises);
            Save(ACTIVITIES_FILE_NAME, Activities);
        }
    }
}
