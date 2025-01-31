using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("de-de");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));

            Console.WriteLine(resourceManager.GetString("EnterUserName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime(resourceManager.GetString("Birthdate", culture), culture, resourceManager);
                var weight = ParseDouble(resourceManager.GetString("Weight", culture), culture, resourceManager);
                var height = ParseDouble(resourceManager.GetString("Height", culture), culture, resourceManager);

                userController.SetNewUserData(gender, birthDate, weight, height);

            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - Ввести приём пищи.");
                Console.WriteLine("A - Ввести упражнение.");
                Console.WriteLine("Q - Выход.");
                var key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating(culture, resourceManager);
                        eatingController.Add(foods.Food, foods.Weight);

                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Food} - {item.Weight} грамм");
                        }
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise(culture, resourceManager);
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, BL.Model.Activity Activity) EnterExercise(CultureInfo culture, ResourceManager resourceManager)
        {
            Console.Write(resourceManager.GetString("EnterExercise", culture));
            var name = Console.ReadLine();

            var energy = ParseDouble(resourceManager.GetString("EnergyPerMinute", culture), culture, resourceManager);

            var begin = ParseDateTime(resourceManager.GetString("StartExercise", culture), culture, resourceManager);
            var end = ParseDateTime(resourceManager.GetString("EndExercise", culture), culture, resourceManager);

            var activity = new Activity(name, energy);

            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating(CultureInfo culture, ResourceManager resourceManager)
        {
            Console.Write(resourceManager.GetString("EnterProduct", culture));
            var food = Console.ReadLine();

            var weight = ParseDouble(resourceManager.GetString("PortionWeight", culture), culture, resourceManager);
            var proteins = ParseDouble(resourceManager.GetString("Proteins", culture), culture, resourceManager);
            var fats = ParseDouble("Жиры", culture, resourceManager);
            var carbohydrates = ParseDouble("Углеводы", culture, resourceManager);
            var calories = ParseDouble("Калории", culture, resourceManager);

            return (Food: new Food(food, proteins, fats, carbohydrates, calories), Weight: weight);
        }

        private static double ParseDouble(string name, CultureInfo culture, ResourceManager resourceManager)
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
                    Console.WriteLine($"Неверный формат поля {name}!");
                }
            }
        }
        private static DateTime ParseDateTime(string value, CultureInfo culture, ResourceManager resourceManager)
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write($"Введите {value} (dd, MM, yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {value}!");
                }
            }
            return birthDate;
        }
    }
}
