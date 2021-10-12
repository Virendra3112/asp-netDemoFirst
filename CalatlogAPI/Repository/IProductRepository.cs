using CalatlogAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalatlogAPI.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();
        Product GetProduct(string id);
        IEnumerable<Product> GetProductsByName(string name);
        IEnumerable<Product> GetProductsByCategory(string category);

        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(string id);

    }
}
