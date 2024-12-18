using System;
using System.Collections.Generic;

namespace MPZ_LR3
{
    public class Admin : IUser
    {
        public string Role => "Адміністратор";

        private List<Product> products = new List<Product>();
        private List<IUser> users = new List<IUser>();

        public void DisplayActions()
        {
            Console.WriteLine("Дії для адміністратора:");
            Console.WriteLine("1. Оновлення інформації про товар");
            Console.WriteLine("2. Керування користувачами");
            Console.WriteLine("3. Формування звітів");
        }

        public void UpdateProductInfo()
        {
            Console.WriteLine("\n=== Оновлення інформації про товар ===");

            Console.Write("Введіть артикул товару для оновлення: ");
            string sku = Console.ReadLine();

            Product productToUpdate = products.Find(p => p.SKU == sku);

            if (productToUpdate == null)
            {
                Console.WriteLine("Товар з таким артикулом не знайдено.");
                return;
            }

            Console.Write("Введіть нову ціну товару: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal newPrice) || newPrice <= 0)
            {
                Console.WriteLine("Ціна повинна бути числом більше нуля.");
                return;
            }

            productToUpdate.Price = newPrice;
            Console.WriteLine("Інформацію про товар успішно оновлено!");
        }

        public void ManageUsers()
        {
            Console.WriteLine("\n=== Керування користувачами ===");
            Console.WriteLine("1. Додати користувача");
            Console.WriteLine("2. Видалити користувача");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddUser();
                    break;
                case "2":
                    RemoveUser();
                    break;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }

        private void AddUser()
        {
            Console.WriteLine("\n=== Додати користувача ===");

            Console.Write("Введіть роль користувача (Менеджер/Працівник/Адміністратор): ");
            string role = Console.ReadLine();

            IUser newUser;
            switch (role.ToLower())
            {
                case "Менеджер":
                    newUser = new Manager();
                    break;
                case "Працівник":
                    newUser = new Worker();
                    break;
                case "Адміністратор":
                    newUser = new Admin();
                    break;
                default:
                    Console.WriteLine("Невірна роль. Користувач не доданий.");
                    return;
            }

            users.Add(newUser);
            Console.WriteLine("Користувача успішно додано!");
        }

        private void RemoveUser()
        {
            Console.WriteLine("\n=== Видалити користувача ===");

            Console.Write("Введіть роль користувача для видалення: ");
            string role = Console.ReadLine();

            IUser userToRemove = users.Find(u => u.Role.Equals(role, StringComparison.OrdinalIgnoreCase));

            if (userToRemove == null)
            {
                Console.WriteLine("Користувача з такою роллю не знайдено.");
                return;
            }

            users.Remove(userToRemove);
            Console.WriteLine("Користувача успішно видалено!");
        }


        public void GenerateReports()
        {
            Console.WriteLine("\n=== Формування звітів ===");

            Console.WriteLine("Формування звітів по товарах:");
            foreach (var product in products)
            {
                Console.WriteLine($"Артикул: {product.SKU}, Ціна: {product.Price:C}");
            }

            Console.WriteLine("\nФормування звітів по користувачах:");
            foreach (var user in users)
            {
                Console.WriteLine($"Користувач: {user.Role}");
            }
        }

    }
}
