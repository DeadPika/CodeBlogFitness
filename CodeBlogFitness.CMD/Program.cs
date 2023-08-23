using CodeBlogFitness.BL.Controller;
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
            Console.ReadLine();
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
                    Console.WriteLine($"Не верный формат {name}!");
                }
            }
        }
    }
}
