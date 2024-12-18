using MPZ_LR3;
using System;
using System.Collections.Generic;

public class Manager : IUser
{
    public string Role => "Менеджер складу";

    private List<Product> products = new List<Product>();

    public void DisplayActions()
    {
        Console.WriteLine("Дії для менеджера складу:");
        Console.WriteLine("1. Прийом товару");
        Console.WriteLine("2. Моніторинг стану складу");
        Console.WriteLine("3. Інвентаризація");
        Console.WriteLine("4. Розрахунок залишків");
    }

    public void AddProduct()
    {
        Console.WriteLine("\n=== Прийом товару ===");

        Console.Write("Введіть артикул товару: ");
        string sku = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(sku))
        {
            Console.WriteLine("Артикул не може бути порожнім.");
            return;
        }

        Console.Write("Введіть ціну товару: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price <= 0)
        {
            Console.WriteLine("Ціна повинна бути числом більше нуля.");
            return;
        }

        if (products.Exists(p => p.SKU == sku))
        {
            Console.WriteLine("Товар з таким артикулом вже існує.");
            return;
        }

        products.Add(new Product(sku, price));
        Console.WriteLine("Товар успішно додано!\n");

        DisplayProducts();
    }

    public void MonitorStock()
    {
        Console.WriteLine("\n=== Моніторинг стану складу ===");

        if (products.Count == 0)
        {
            Console.WriteLine("Склад порожній.");
        }
        else
        {
            DisplayProducts();
        }
    }

    public void InventoryCheck()
    {
        Console.WriteLine("\n=== Інвентаризація ===");

        foreach (var product in products)
        {
            Console.WriteLine($"Артикул: {product.SKU}, Ціна: {product.Price}");
        }
    }

    public void CalculateRemainingStock()
    {
        Console.WriteLine("\n=== Розрахунок залишків ===");

        decimal totalValue = 0;
        foreach (var product in products)
        {
            totalValue += product.Price;
        }

        Console.WriteLine($"Загальна вартість товарів на складі: {totalValue:C}");
    }

    private void DisplayProducts()
    {
        Console.WriteLine("Поточний список товарів:");
        foreach (var product in products)
        {
            Console.WriteLine($"Артикул: {product.SKU}, Ціна: {product.Price:C}");
        }
    }
}
