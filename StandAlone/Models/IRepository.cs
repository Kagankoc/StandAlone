using System.Collections.Generic;

namespace StandAlone.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
        void DeleteProduct(Product product);
    }
}
