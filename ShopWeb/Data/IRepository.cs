using System.Collections.Generic;
using System.Threading.Tasks;
using ShopWeb.Data.Entities;

namespace ShopWeb.Data
{
    public interface IRepository
    {
        void AddProduct(Product product);

        Product GetProductById(int id);

        IEnumerable<Product> GetProducts();

        bool ProductExists(int id);

        void RemoveProduct(Product product);

        Task<bool> SaveAllasync();

        void UpdateProduct(Product product);
    }
}