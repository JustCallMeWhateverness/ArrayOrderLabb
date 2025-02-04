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

            // private int _count;
            // private int initial_Capacity;
            // TODO: Add product to array

            // check if _product contains null. Save all places with null in a array or similar.
            // make other method for checking for null in a thing.   
            // if contains null, take the first place with null and put the product there
            
            // if not: 
            // create new array size _products.length*2
            // put all the things into it with loop
            // add the last thing at last index.
            
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
    }
}
