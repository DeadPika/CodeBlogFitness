using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол Пользователя: ");
                var genderName = Console.ReadLine();
                var birthDate = ParseDateTime("дату рождения (Например: 02.01.2008)");
                var weight = ParseDouble("веса");
                var height = ParseDouble("роста");

                userController.SetNewUserData(genderName, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            while (true) {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("Е - ввести приём пищи.");
                Console.WriteLine("A - ввести упражнение.");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
            }
        Console.ReadLine();
        }
        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var nameActivity = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало время начала упражнения (Например: 02.01.2008 00:00)");
            var end = ParseDateTime("окончание времени упражнения (Например: 02.01.2008 01:00)");

            var activity = new Activity(nameActivity, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("Введите название продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("протеины");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");
            var product = new Food(food, calories, prots, fats, carbs);

            var weight = ParseDouble("вес порции");

            return  (Food: product, Weight: weight);
        }
        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value}: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}!");
                }
            }
        }
        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат {name}а!");
                }
            }
        }
    }
}
