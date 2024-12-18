using MPZ_LR3;
using System;

class Program
{
    static void Main()
    {
        IUser user = SelectUser();

        Console.WriteLine($"\nВи увійшли як: {user.Role}");
        SystemMenu systemMenu = new SystemMenu();
        systemMenu.Run(user);
    }

    private static IUser SelectUser()
    {
        while (true)
        {
            Console.WriteLine("\nОберіть тип користувача:");
            Console.WriteLine("1. Адміністратор");
            Console.WriteLine("2. Менеджер складу");
            Console.WriteLine("3. Працівник складу");
            Console.Write("Введіть число: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    return new Admin();
                case "2":
                    return new Manager();
                case "3":
                    return new Worker();
                default:
                    Console.WriteLine("Неправильний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}