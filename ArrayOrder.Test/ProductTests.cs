using System;
using Xunit;
using ArrayOrder.Core.Models;

namespace ArrayOrder.Test
{
    public class ProductTests
    {
        [Fact]
        public void TestUpdateStock_Delivery_IncreasesStock()
        {
            // Arrange
            var product = new Product(1, "Laptop", "Elektronik", 15000, 5);

            // Act
            product.UpdateStock(10, true);

            // Assert
            Assert.Equal(15, product.ILager);
        }
        [Fact]
        public void TestUpdateStock_Delivery_DecreasesStock()
        {
            // Arrange
            var product = new Product(1, "Laptop", "Elektronik", 15000, 10);

            // Act
            product.UpdateStock(5, false);

            // Assert
            Assert.Equal(5, product.ILager);
        }
        [Fact]
        public void TestUpdateStock_Delivery_AmountZero_ThrowsException()
        {
            // Arrange
             var product = new Product(1, "Laptop", "Elektronik", 15000, 5);


            // Act & Assert
            Assert.Throws<ArgumentException>(()  => product.UpdateStock(0, true));
        }
        [Fact]
        public void TestUpdateStock_Delivery_AmountLessThenZero_ThrowsException()
        {
            // Arrange
             var product = new Product(1, "Laptop", "Elektronik", 15000, 5);


            // Act & Assert
            Assert.Throws<ArgumentException>(()  => product.UpdateStock(-10, true));
        }

         [Fact]
        public void TestUpdateStock_Sell_AmountZero_ThrowsException()
        {
            // Arrange
             var product = new Product(1, "Laptop", "Elektronik", 15000, 5);


            // Act & Assert
            Assert.Throws<ArgumentException>(()  => product.UpdateStock(0, false));
        }
        [Fact]
        public void TestUpdateStock_Sell_AmountLessThenZero_ThrowsException()
        {
            // Arrange
             var product = new Product(1, "Laptop", "Elektronik", 15000, 5);


            // Act & Assert
            Assert.Throws<ArgumentException>(()  => product.UpdateStock(-10, false));
        }


        [Fact]
        public void TestUpdateStock_Sell_ExceedsLimit_ThrowsException()
        {
            // Arrange
            var product = new Product(1, "Laptop", "Elektronik", 15000, 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.UpdateStock(6, false));


        }

        
        [Fact]
        public void TestUpdateStock_Delivery_ExceedsLimit_ThrowsException()
        {
            // Arrange
            var product = new Product(1, "Laptop", "Elektronik", 15000, 5);

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => product.UpdateStock(10001, true));


        }

        // TODO: Add more tests
    }
}