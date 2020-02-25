using System.Collections.Generic;

namespace StandAlone.Models
{
    public class Repository : IRepository
    {
        private List<Product> products;

        public Repository()
        {
            products = new List<Product>();
            new List<Product>()
            {
                new Product {Name = "Basketball", Price = 3.99M},
                new Product {Name = "Shirt", Price = 4.99M},
                new Product {Name = "Pants", Price = 19.99M}
            }.ForEach(AddProduct);
        }

        public IEnumerable<Product> Products => products;

        public void AddProduct(Product product) => products.Add(product);


        public void DeleteProduct(Product product) => products.Remove(product);

    }
}
