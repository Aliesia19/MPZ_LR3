using MPZ_LR3;
using System;

public class SystemMenu
{
    public void Run(IUser user)
    {
        switch (user)
        {
            case Manager manager:
                ManagerMenu(manager);
                break;

            case Worker worker:
                WorkerMenu(worker);
                break;

            case Admin admin:
                AdminMenu(admin);
                break;
        }
    }

    private void ManagerMenu(Manager manager)
    {
        while (true)
        {
            Console.WriteLine("\nОберіть дію для Менеджера (введіть номер): ");
            Console.WriteLine("1. Прийом товару");
            Console.WriteLine("2. Моніторинг стану складу");
            Console.WriteLine("3. Інвентаризація");
            Console.WriteLine("4. Розрахунок залишків");
            Console.WriteLine("0. Вихід");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    manager.AddProduct();
                    break;
                case "2":
                    manager.MonitorStock();
                    break;
                case "3":
                    manager.InventoryCheck();
                    break;
                case "4":
                    manager.CalculateRemainingStock();
                    break;
                case "0":
                    Console.WriteLine("Вихід із системи...");
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private void WorkerMenu(Worker worker)
    {
        while (true)
        {
            Console.WriteLine("\nОберіть дію для Працівника (введіть номер): ");
            Console.WriteLine("1. Перегляд інформації про товар");
            Console.WriteLine("2. Відправка товару");
            Console.WriteLine("0. Вихід");
            string choice = Console.ReadLine();

            if (choice == "1")
                worker.ViewProductInfo();
            else if (choice == "2")
                worker.ShipProduct();
            else if (choice == "0")
            {
                Console.WriteLine("Вихід із системи...");
                break;
            }
            else
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
        }
    }

    private void AdminMenu(Admin admin)
    {
        while (true)
        {
            Console.WriteLine("\nОберіть дію для Адміністратора (введіть номер): ");
            Console.WriteLine("1. Оновлення інформації про товар");
            Console.WriteLine("2. Керування користувачами");
            Console.WriteLine("3. Формування звітів");
            Console.WriteLine("0. Вихід");
            string choice = Console.ReadLine();

            if (choice == "1")
                admin.UpdateProductInfo();
            else if (choice == "2")
                admin.ManageUsers();
            else if (choice == "3")
                admin.GenerateReports();
            else if (choice == "0")
            {
                Console.WriteLine("Вихід із системи...");
                break;
            }
            else
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
        }
    }
}
