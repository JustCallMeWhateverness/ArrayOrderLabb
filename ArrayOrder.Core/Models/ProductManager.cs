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
            // Are there any empty spots available?
            bool nullFound = false;
            int nullIndex = 0;
            do
            {
                if (_products[nullIndex] == null)
                {
                    nullFound = true;
                }
                else
                {
                    nullIndex++;
                }
            }while (!nullFound ||  nullIndex < _products.Length);

            // If there are empty spots available, use them!
            if (nullFound)
            {
                _products[nullIndex] = product;
            }
            else
            {
                // If there aren't any spots available, make some more :) 
                _products = CloneAndIncreaseSizeOfArray();
                _products[_products.Length] = product;
            }
            
        }

        private Product[] CloneAndIncreaseSizeOfArray()
        {
            var longerArray = new Product[_products.Length * 2];
            return longerArray = (Product[])_products.Clone();
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
