using System;
using Xunit;
using ArrayOrder.Core.Models;

namespace ArrayOrder.Test
{
    public class ProductManagerTests
    {
        private ProductManager CreateProductManagerWithSampleData()
        {
            var manager = new ProductManager(5);
            manager.AddProduct(new Product(1, "Laptop", "Elektronik", 15000, 5));
            manager.AddProduct(new Product(2, "T-shirt", "Kläder", 200, 20));
            manager.AddProduct(new Product(3, "Bok", "Böcker", 150, 10));
            manager.AddProduct(new Product(4, "Telefon", "Elektronik", 5000, 8));
            manager.AddProduct(new Product(5, "Skor", "Kläder", 800, 15));
            return manager;
        }

        [Fact]
        public void TestSortByPrice_Ascending()
        {
            // Arrange
            var manager = CreateProductManagerWithSampleData();

            // Act
            var sorted = manager.SortByPrice(true);

            // Assert
            Assert.Equal(150, sorted[0].Pris);
            Assert.Equal(200, sorted[1].Pris);
            Assert.Equal(800, sorted[2].Pris);
            Assert.Equal(5000, sorted[3].Pris);
            Assert.Equal(15000, sorted[4].Pris);
        }

        [Fact]
        public void TestSortByPrice_Descending()
        {
            // Arrange

            // Act

            // Assert
        }

        [Fact]
        public void TestSortByName()
        {
            // Arrange

            // Act

            // Assert
        }

        // TODO: Add more tests
    }
}
