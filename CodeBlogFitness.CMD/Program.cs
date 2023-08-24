using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using System;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogeFitness от Gavr`а.");

            Console.WriteLine("Введите имя Пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол Пользователя: ");
                var genderName = Console.ReadLine();
                var birthDate = ParseDateTime();
                var weight = ParseDouble("веса");
                var height = ParseDouble("роста");

                userController.SetNewUserData(genderName, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести приём пищи");
            var key = Console.ReadKey();
            Console.WriteLine();
            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();
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
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите день рождения(Пример: 01.02.2008): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    return birthDate;
                }
                else
                {
                    Console.WriteLine("Не верный формат даты!");
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
