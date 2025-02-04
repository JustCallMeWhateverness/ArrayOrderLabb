using System;

namespace ArrayOrder.Core.Models
{
    public class ProductManager
    {
        private Product[] _products;
        private int _count;

        public ProductManager(int initialCapacity)
        {
            if (initialCapacity <= 0)
            {
                throw new ArgumentException("Initial capacity must be greater than zero.", nameof(initialCapacity));
            }
            _products = new Product[initialCapacity];
            _count = 0;
        }

        public void AddProduct(Product product)
        {
            if (_count >= _products.Length)
            {
                _products = CloneAndIncreaseSizeOfArray();
            }
            _products[_count] = product;

            _count++;
        }

        private Product[] CloneAndIncreaseSizeOfArray()
        {
            var length = _products.Length * 2;
            var longerArray = new Product[length];
            _products.CopyTo(longerArray, 0);

            return longerArray;
        }
        public Product[] SortByPrice(bool ascending = true)
        {
            // TODO: Implement sorting
            return (Product[])_products.Clone();
        }

        public Product[] SortByName()
        {
            // TODO: Implement sorting
            return (Product[])_products.Clone();
        }

        public Product[] SortByCategory()
        {
            // TODO: Implement sorting
            return (Product[])_products.Clone();
        }

        public Product[] FilterByPriceRange(decimal minPrice, decimal maxPrice)
        {
            // TODO: Implement filtering
            return (Product[])_products.Clone();
        }

        public Product[] FilterByStockStatus(bool inStock)
        {
            // TODO: Implement filtering
            return (Product[])_products.Clone();
        }

        public Product[] FilterByCategory(string category)
        {
            // TODO: Implement filtering
            return (Product[])_products.Clone();

        }

        public Product[] GetProducts()
        {
            return _products;
        }
    }
}
