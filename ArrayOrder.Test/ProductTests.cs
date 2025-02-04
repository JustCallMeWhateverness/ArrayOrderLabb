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
        public void TestUpdateStock_Delivery_InvalidAmount_ThrowsException()
        {
            // Arrange

            // Act & Assert
        }

        [Fact]
        public void TestUpdateStock_Delivery_ExceedsLimit_ThrowsException()
        {
            // Arrange

            // Act & Assert
        }

        // TODO: Add more tests
    }
}