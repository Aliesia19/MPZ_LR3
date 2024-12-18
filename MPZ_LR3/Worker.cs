using System;
using System.Collections.Generic;

namespace MPZ_LR3
{
    public class Worker : IUser
    {
        private List<Product> products;
        public string Role => "Працівник складу";

        public Worker(List<Product> initialProducts)
        {
            products = initialProducts ?? new List<Product>();
        }

        public Worker()
        {
            products = new List<Product>
            {
                new Product("001фі", 100m),
                new Product("002фі", 200m)
            };
        }

        public void DisplayActions()
        {
            Console.WriteLine("Дії для працівника складу:");
            Console.WriteLine("1. Перегляд інформації про товар");
            Console.WriteLine("2. Відправка товару");
        }

        public void ViewProductInfo()
        {
            Console.WriteLine("\n=== Перегляд інформації про товар ===");

            if (products.Count == 0)
            {
                Console.WriteLine("Склад порожній.");
                return;
            }

            foreach (var product in products)
            {
                Console.WriteLine($"Артикул: {product.SKU}, Ціна: {product.Price:C}");
            }
        }
        public void ShipProduct()
        {
            Console.WriteLine("\n=== Відправка товару ===");

            Console.Write("Введіть артикул товару для відправки: ");
            string sku = Console.ReadLine();

            Product productToShip = products.Find(p => p.SKU == sku);

            if (productToShip == null)
            {
                Console.WriteLine("Товар з таким артикулом не знайдено.");
                return;
            }

            products.Remove(productToShip);
            Console.WriteLine("Товар успішно відправлено!");

            DisplayProducts();
        }

        private void DisplayProducts()
        {
            Console.WriteLine("\nПоточний список товарів:");
            foreach (var product in products)
            {
                Console.WriteLine($"Артикул: {product.SKU}, Ціна: {product.Price:C}");
            }
        }
    }
}
