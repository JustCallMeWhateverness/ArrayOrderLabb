using System;
using ArrayOrder.Core.Models;

namespace ArrayOrder.Cli
{
    class Program
    {
        static void Main(string[] args)
        {
            var productManager = new ProductManager(5);
            productManager.AddProduct(new Product(1, "Laptop", "Elektronik", 15000, 5));
            productManager.AddProduct(new Product(2, "T-shirt", "Kläder", 200, 20));
            productManager.AddProduct(new Product(3, "Bok", "Böcker", 150, 10));
            productManager.AddProduct(new Product(4, "Telefon", "Elektronik", 5000, 8));
            productManager.AddProduct(new Product(5, "Skor", "Kläder", 800, 15));

            Console.WriteLine("Produkter sorterade efter pris (stigande):");
            foreach (var product in productManager.SortByPrice(true))
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nProdukter sorterade efter namn:");
            foreach (var product in productManager.SortByName())
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nProdukter i kategorin 'Elektronik':");
            foreach (var product in productManager.FilterByCategory("Elektronik"))
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nProdukter i lager:");
            foreach (var product in productManager.FilterByStockStatus(true))
            {
                Console.WriteLine(product);
            }

            Console.WriteLine("\nProdukter inom prisintervallet 200 till 1000 kr:");
            foreach (var product in productManager.FilterByPriceRange(200, 1000))
            {
                Console.WriteLine(product);
            }
        }
    }
}
