using System;
using System.Collections.Generic;
using System.Linq;

namespace protopkuis1
{
    public class ProductService
    {
        private List<Product> products;

        public ProductService()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        public List<Product> SearchByName(string keyword)
        {
            return products.Where(p => p.Name.ToLower().Contains(keyword.ToLower())).ToList();
        }

        public List<Product> SearchByPriceRange(double minPrice, double maxPrice)
        {
            return products.Where(p => p.Price >= minPrice && p.Price <= maxPrice).ToList();
        }

        public List<Product> SortByStock()
        {
            return products.OrderByDescending(p => p.Stock).ToList();
        }
    }
}
